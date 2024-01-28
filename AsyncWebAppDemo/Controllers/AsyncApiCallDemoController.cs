using AsyncWebAppDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsyncWebAppDemo.Controllers
{
    public class AsyncApiCallDemoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AsyncApiCallDemoController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// to be used
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            AsyncApiCallDemoModel model = new AsyncApiCallDemoModel();
            model.OutputMessages.Add("please click the button");
            return View(model);
        }

        /// <summary>
        /// to be used
        /// </summary>
        /// <returns></returns>
        public JsonResult GetApiCall()
        {
            AsyncApiCallDemoModel model = new AsyncApiCallDemoModel();
            model.GetApiCallSync();
            return new JsonResult(model);

        }

        public IActionResult IntermediateDemo()
        {
            AsyncApiCallDemoModel model = new AsyncApiCallDemoModel();
            model.OutputMessages.Add("please click the button");
            return View(model);
        }
        public async Task<JsonResult> GetApiCallIntermediate()
        {
            AsyncApiCallDemoModel model = new AsyncApiCallDemoModel();
            await model.GetApiCallAsync();
            return new JsonResult(model);

        }
        
        /// <summary>
        /// to be used
        /// </summary>
        /// <returns></returns>
        public IActionResult ConcurrentDemo()
        {
            AsyncApiCallDemoModel model = new AsyncApiCallDemoModel();
            model.OutputMessages.Add("please click the button");
            return View(model);
        }
       
        public class Information
        {
            public string Name { get; set; }
        }
        [HttpPost]
        public async Task<JsonResult> GetApiCallConcurrentOptimizedAll([FromBody] Information input)
        {
            AsyncApiCallDemoModel model = new AsyncApiCallDemoModel();
            switch (input.Name)
            {
                case "GetApiCallConcurrent":
                    await model.GetApiCallConcurrent();
                    break;
         
                case "GetApiCallConcurrentOptimizedAll":
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