using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Provision.Data;
using Provision.Entities;

namespace ProvisionWEB.Controllers
{
    
    [Route("api/Currency")]
    public class CurrencyRest : Controller
    {

        private DatabaseContext db = new
            DatabaseContext();

        [HttpGet("findall")]
        [Produces("application/json")]
        public async Task<IActionResult>findAll()
            {
            try
            {
                var currencys = db.Currencies.ToList();
                return Ok(currencys);
            }
            catch 
            {

                return BadRequest();
            }
            }
        
    }
}
