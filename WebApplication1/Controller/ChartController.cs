using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Provision.Worker;
using System.Threading;

namespace ProvisionWEB.Controllers
{
    [Route("Currency")]
    public class ChartController : Controller
    {

        [HttpGet("/api/[controller]")]
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            TcmbWorker worker = new TcmbWorker();
            worker.StartAsync(new CancellationToken());
            return View();
        }
    }
}
