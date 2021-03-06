#pragma checksum "C:\Users\alper\source\repos\ProvisionpayCurrencyChart\WebApplication1\Views\Chart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72f96ac310e96f96ddb0a153acafff060b5eed61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chart_Index), @"mvc.1.0.view", @"/Views/Chart/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72f96ac310e96f96ddb0a153acafff060b5eed61", @"/Views/Chart/Index.cshtml")]
    public class Views_Chart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72f96ac310e96f96ddb0a153acafff060b5eed612726", async() => {
                WriteLiteral(@"
    <title>PROV??S??ON CURRENCY</title>
    <script type=""text/javascript"" src=""https://www.google.com/jsapi""></script>
    <script type=""text/javascript"" src=""https://www.google.com/jsapi""></script>
    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js""></script>
    <!-- Load d3.js -->
    <script src=""https://d3js.org/d3.v4.js""></script>

    <!-- Create a div where the graph will take place -->

    <script>
        $(document).ready(function () {
            

            LoadChart();

            $(""#ddlCurrencies"").on(""change"", function () {
                LoadChart();
            });

            function LoadChart() {
                $.ajax({
                    type: ""GET"",
                    dataType: ""json"",
                    contentType: ""application/json"",
                    url: '/api/currency/findAll',
                    success: function (resu");
                WriteLiteral(@"lt) {
                        google.charts.load('current', {
                            'packages': ['corechart']
                        });
                        google.charts.setOnLoadCallback(function () {
                            drawChart(result);
                        });
                    }
                });
                function ParseDate(date) {
                    date = date.substring(0, 10);
                    return d3.timeParse(""%Y-%m-%d"")(date);
                };

                var margin = { top: 10, right: 30, bottom: 30, left: 60 },
                    width = 460 - margin.left - margin.right,
                    height = 400 - margin.top - margin.bottom;

              

                function drawChart(result) {
                    var data = new google.visualization.DataTable();
                    data.addColumn('string', 'CurrencyCode');
                    data.addColumn('number', 'Value');
                    data.addColumn('date', 'Date'");
                WriteLiteral(@");
                    var dataArray = [];

                    var currencyOptionset = document.getElementById(""ddlCurrencies"");

                    $.each(result, function (i, obj) {
                        if (currencyOptionset.value == obj.currencyCode)
                            dataArray.push([obj.currencyCode, obj.effectiveBuyingAmount, ParseDate(obj.insertDate)]);
                    });             
                    GenerateChart(dataArray);
                    
                };
                function GenerateChart(data) { 
                    document.getElementById(""Piechart_div"").innerHTML = """";
                    var svg = d3.select(""#Piechart_div"")
                        .append(""svg"")
                        .attr(""width"", width + margin.left + margin.right)
                        .attr(""height"", height + margin.top + margin.bottom)
                        .append(""g"")
                        .attr(""transform"",
                            ""translate("" + margin.le");
                WriteLiteral(@"ft + "","" + margin.top + "")"");
                    
                    var x = d3.scaleTime()
                        .domain(d3.extent(data, function(d) { return d[""2""]; }))
                        .range([0, width]);
                    svg.append(""g"")
                        .attr(""transform"", ""translate(0,"" + height + "")"")
                        .call(d3.axisBottom(x));
                   
                    var y = d3.scaleLinear()
                        .domain([0, d3.max(data, function(d) { return +d[""1""]; })])
                        .range([height, 0]);
                    svg.append(""g"")
                        .call(d3.axisLeft(y));

                    // Add the line
                    svg.append(""path"")
                        .datum(data)
                        .attr(""fill"", ""none"")
                        .attr(""stroke"", ""steelblue"")
                        .attr(""stroke-width"", 1.5)
                        .attr(""d"", d3.line()
                            .x(function");
                WriteLiteral(@"(d) {
                                return x(d[""2""])
                            })
                            .y(function(d) {
                                return y(d[""1""])
                            })
                        )
                };                           
            }
        });
    </script>




");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72f96ac310e96f96ddb0a153acafff060b5eed618355", async() => {
                WriteLiteral(@"
    <div>
        <label><b>Central Bank of the Republic of Turkey Exchange Rates Chart</b></label><br /><br />
        <table border=""0"" cellpadding=""0"" cellspacing=""0"">
            <br />
            <tr>

                <td>
                    <label for=""cars"">Choose a Currency:</label>
                    <select id=""ddlCurrencies"">
                        <option value=""USD"">USD</option>
                        <option value=""EUR"">EUR</option>
                        <option value=""AUD"">AUD</option>
                        <option value=""DKK"">DKK</option>
                        <option value=""GBP"">GBP</option>
                        <option value=""CHF"">CHF</option>
                        <option value=""SEK"">SEK</option>
                        <option value=""CAD"">CAD</option>
                        <option value=""KWD"">KWD</option>
                        <option value=""NOK"">NOK</option>
                        <option value=""SAR"">SAR</option>
                        <option v");
                WriteLiteral("alue=\"JPY\">JPY</option>\r\n\r\n                    </select><br />\r\n                </td>\r\n            </tr>\r\n        </table><br /><br />\r\n    </div>\r\n    <div id=\"Piechart_div\"></div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
