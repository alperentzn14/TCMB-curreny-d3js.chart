using Microsoft.Extensions.Hosting;
using Provision.Data;
using Provision.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Provision.Worker
{
    public class TcmbWorker : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var now = DateTime.Today;
                var endDate = now.AddMonths(-2);
                var dateRange = (now - endDate).Days;

                for (int i = 0; i < dateRange; i++)
                {
                    DateTime date = now;
                    string url = null;

                    if (i == 0)
                        url = "https://www.tcmb.gov.tr/kurlar/today.xml";
                    else
                    {
                        date = now.AddDays(-i);
                        url = $"https://www.tcmb.gov.tr/kurlar/{date.Year}{date.Month.ToString().PadLeft(2, '0')}/{date.Day.ToString().PadLeft(2, '0')}{date.Month.ToString().PadLeft(2, '0')}{date.Year}.xml";
                    }

                    var results = GetCurrencyFromTCMB(url);

                    if (results == null || results.Count == 0)
                        continue;

                    var db = new EfCurrencyDal();

                    foreach (var currency in results)
                    {
                        currency.InsertDate = date;

                        var record = db.Get(k => k.InsertDate == date && k.CurrencyCode == currency.CurrencyCode);

                        if (record != null)
                            continue;

                        db.Add(currency);
                    }
                }
            });
        }

        private static List<Currency> GetCurrencyFromTCMB(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = "GET";

            string content = null;

            try
            {
                using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    content = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            if (string.IsNullOrEmpty(content))
                return null;

            var xml = new XmlDocument();
            xml.LoadXml(content);

            var childNode = xml["Tarih_Date"];

            if (childNode == null)
                return null;

            var results = new List<Currency>();
            foreach (XmlNode currencyNode in childNode)
            {
                if (currencyNode.Attributes == null || currencyNode.Attributes.Count == 0)
                    continue;

                try
                {
                    var currencyCode = currencyNode.Attributes["CurrencyCode"];
                    if (currencyCode == null)
                        continue;
                    var currency = new Currency
                    {
                        CurrencyCode = currencyCode.Value,
                    };

                    foreach (XmlNode child in currencyNode.ChildNodes)
                    {
                        if (child.Name == "Unit" && int.TryParse(child.InnerText, out var unit))
                            currency.Unit = unit;
                        else if (child.Name == "ForexBuying" && decimal.TryParse(child.InnerText.Replace(".",","), out var forexBuying))
                            currency.ForexBuyingAmount = forexBuying;
                        else if (child.Name == "ForexSelling" && decimal.TryParse(child.InnerText.Replace(".", ","), out var forexSelling))
                            currency.ForexSellingAmount = forexSelling;
                        else if (child.Name == "BanknoteBuying" && decimal.TryParse(child.InnerText.Replace(".", ","), out var banknoteBuying))
                            currency.EffectiveBuyingAmount = banknoteBuying;
                        else if (child.Name == "BanknoteSelling" && decimal.TryParse(child.InnerText.Replace(".", ","), out var banknoteSelling))
                            currency.EffectiveSellingAmount = banknoteSelling;
                    }

                    results.Add(currency);
                }
                catch
                {
                }
            }

            return results;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
