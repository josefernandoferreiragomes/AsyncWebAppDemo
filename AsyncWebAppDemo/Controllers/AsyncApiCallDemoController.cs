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

        
        public IActionResult Index()
        {
            AsyncApiCallDemoModel model = new AsyncApiCallDemoModel();
            model.OutputMessages.Add("please select service call test");
            return View(model);
        }

       
        [HttpPost]
        public async Task<JsonResult> GetApiCallConcurrentOptimizedAll([FromBody] Information input)
        {
            AsyncApiCallDemoModel model = new AsyncApiCallDemoModel();
            switch (input.Name)
            {
                case "GetApiCallSync":
                    model.GetApiCallSync();
                    break;
                case "GetApiCallAsync":
                    await model.GetApiCallAsync();
                    break;
                case "GetApiCallConcurrent":
                    await model.GetApiCallConcurrent();
                    break;         
                case "GetApiCallConcurrentOptimized":
                    await model.GetApiCallConcurrentOptimized();
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