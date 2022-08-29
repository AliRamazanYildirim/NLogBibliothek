using Microsoft.AspNetCore.Mvc;
using NLogBibliothek.Models;
using System.Diagnostics;

namespace NLogBibliothek.Controllers
{
    public class HomeController : Controller
    {
        //1. Weg

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    _logger.LogTrace("Indexseite wurde eingegeben.-Trace");
        //    _logger.LogDebug("Indexseite wurde eingegeben.-Debug");
        //    _logger.LogInformation("Indexseite wurde eingegeben.");
        //    _logger.LogWarning("Indexseite wurde eingegeben.-Warning");
        //    _logger.LogError("Indexseite wurde eingegeben.-Error");
        //    _logger.LogCritical("Indexseite wurde eingegeben.-Critical");
        //    return View();
        //}

        //2.Weg wenn man einen benutzerdefinierten Name verwenden möchte
        private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        
        public IActionResult Index()
        {
            var _logger= _loggerFactory.CreateLogger("Logging Kategorien");
            _logger.LogTrace("Indexseite wurde eingegeben.-Trace");
            _logger.LogDebug("Indexseite wurde eingegeben.-Debug");
            _logger.LogInformation("Indexseite wurde eingegeben.");
            _logger.LogWarning("Indexseite wurde eingegeben.-Warning");
            _logger.LogError("Indexseite wurde eingegeben.-Error");
            _logger.LogCritical("Indexseite wurde eingegeben.-Critical");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}