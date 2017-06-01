using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        readonly IConfiguration _config;
        readonly IOptions<MyConfig> _myConfig;
        readonly ILogger _logger;
        readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IOptions<MyConfig> myConfig, IConfiguration config, ILoggerFactory loggerFactory, IHostingEnvironment hostingEnvironment)
        {
            _config = config;
            _myConfig = myConfig;
            _logger = loggerFactory.CreateLogger<HomeController>();
            _hostingEnvironment = hostingEnvironment;
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
            var telemetry = new TelemetryClient();
            telemetry.TrackEvent("About");

            ViewData["Message"] = $"App name is '{_myConfig.Value.AppName}', Secret is '{_myConfig.Value.BigSecret}', Db='{_config.GetConnectionString("MyDatabase")}, WebRootPath='{_hostingEnvironment.WebRootPath}'";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            throw new Exception("Contact is busted :(");

            //return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
