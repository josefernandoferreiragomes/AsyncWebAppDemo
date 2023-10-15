using AsyncWebAppDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsyncWebAppDemo.Controllers
{
    public class AsyncDemoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AsyncDemoController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            AsyncDemoModel model = new AsyncDemoModel();
            model.OutputMessages.Add("please click the button");
            return View(model);
        }

        public JsonResult GetBreakfast()
        {
            AsyncDemoModel model = new AsyncDemoModel();
            model.CookBreakfast();
            return new JsonResult(model);

        }

        public IActionResult IntermediateDemo()
        {
            AsyncDemoModel model = new AsyncDemoModel();
            model.OutputMessages.Add("please click the button");
            return View(model);
        }
        public async Task<JsonResult> GetBreakfastIntermediate()
        {
            AsyncDemoModel model = new AsyncDemoModel();
            await model.CookBreakfastIntermediate();
            return new JsonResult(model);

        }
        
        public IActionResult ConcurrentDemo()
        {
            AsyncDemoModel model = new AsyncDemoModel();
            model.OutputMessages.Add("please click the button");
            return View(model);
        }
        public async Task<JsonResult> GetBreakfastConcurrent()
        {
            AsyncDemoModel model = new AsyncDemoModel();
            await model.CookBreakfastConcurrently();
            return new JsonResult(model);

        }
        
        public async Task<JsonResult> GetBreakfastConcurrentOptimized()
        {
            AsyncDemoModel model = new AsyncDemoModel();
            await model.CookBreakfastConcurrentlyOptimized();
            return new JsonResult(model);

        }

        public async Task<JsonResult> GetBreakfastConcurrentOptimizedException()
        {
            AsyncDemoModel model = new AsyncDemoModel();
            await model.CookBreakfastConcurrentlyOptimizedException();
            return new JsonResult(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}