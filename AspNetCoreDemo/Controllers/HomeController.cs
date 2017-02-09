using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace AspNetCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        readonly IOptions<MyConfig> _config;
        readonly ILogger _logger;

        public HomeController(IOptions<MyConfig> config, ILoggerFactory loggerFactory)
        {
            _config = config;
            _logger = loggerFactory.CreateLogger<HomeController>();
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Some information log");
            _logger.LogWarning("This is a warning");
            _logger.LogError("This is an error");

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
