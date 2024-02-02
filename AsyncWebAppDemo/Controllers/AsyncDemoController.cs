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

        //public IActionResult Index()
        //{
        //    AsyncDemoModel model = new AsyncDemoModel();
        //    model.OutputMessages.Add("please click the button");
        //    return View(model);
        //}

        //public JsonResult GetBreakfast()
        //{
        //    AsyncDemoModel model = new AsyncDemoModel();
        //    model.CookBreakfast();
        //    return new JsonResult(model);

        //}

        //public IActionResult IntermediateDemo()
        //{
        //    AsyncDemoModel model = new AsyncDemoModel();
        //    model.OutputMessages.Add("please click the button");
        //    return View(model);
        //}
        //public async Task<JsonResult> GetBreakfastIntermediate()
        //{
        //    AsyncDemoModel model = new AsyncDemoModel();
        //    await model.CookBreakfastIntermediate();
        //    return new JsonResult(model);

        //}
        
        public IActionResult ConcurrentDemo()
        {
            AsyncDemoModel model = new AsyncDemoModel();
            model.OutputMessages.Add("please click the button");
            return View(model);
        }
       
     
        [HttpPost]
        public async Task<JsonResult> GetBreakfastConcurrentOptimizedAll([FromBody] Information input)
        {
            AsyncDemoModel model = new AsyncDemoModel();
            switch (input.Name)
            {
                case "GetBreakfastSync":
                    model.CookBreakfast();
                    break;
                case "GetBreakfastAsync":
                    await model.CookBreakfastIntermediate();
                    break;
                case "GetBreakfastConcurrent":
                    await model.CookBreakfastConcurrently();
                    break;
                case "GetBreakfastConcurrentOptimized":
                    await model.CookBreakfastConcurrentOptimized();
                    break;
                case "GetBreakfastConcurrentOptimizedException":
                    await model.CookBreakfastConcurrentOptimizedException();
                    break;
                case "GetBreakfastConcurrentOptimizedAll":
                    await model.CookBreakfastConcurrentlyOptimizedAll();
                    break;
            }
            
            
            return new JsonResult(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}