using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        readonly IOptions<MyConfig> _config;

        public HomeController(IOptions<MyConfig> config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = $"App name is '{_config.Value.AppName}', Secret is '{_config.Value.BigSecret}'";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
