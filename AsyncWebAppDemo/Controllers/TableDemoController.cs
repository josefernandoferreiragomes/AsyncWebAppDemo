using AsyncWebAppDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsyncWebAppDemo.Controllers
{
    public class TableDemoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public TableDemoController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new TableDemoModel();
            return View(model);
        }

        public IActionResult Transposed()
        {
            var model = new TableDemoModel();
            return View(model);
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}