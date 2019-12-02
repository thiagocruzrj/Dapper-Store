using System;
using Microsoft.AspNetCore.Mvc;

namespace DapperStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("error")]
        public IActionResult Index()
        {
            throw new Exception("We're done when I say we're done");
        }
    }
}