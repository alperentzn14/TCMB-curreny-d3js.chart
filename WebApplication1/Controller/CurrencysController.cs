using Microsoft.AspNetCore.Mvc;
using Provision.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Provision.Entities;
using System.Net.Http;
using System.Xml;

namespace Provision.Controllers
{
    [Route("api/Currencys")]
    public class CurrencysController : Controller
    {
        ICurrencyDal _currencyDal;

        public CurrencysController(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal;
        }


        [HttpGet("")]
        public IActionResult Get()
        {
            var currencys = _currencyDal.GetList();
            return Ok(currencys);
        }

        public IActionResult Post(Currency currencys)
            {
                try
                {
                    _currencyDal.Add(currencys);
                    return new StatusCodeResult(201);
                }
                catch
                {


                }
                return BadRequest();
            }
    }
}
