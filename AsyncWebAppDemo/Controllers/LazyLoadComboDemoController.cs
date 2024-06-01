using AsyncWebAppDemo.Models;
using AsyncWebAppDemo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsyncWebAppDemo.Controllers
{
    public class LazyLoadComboDemoController : Controller
    {
        private readonly ILogger<LazyLoadComboDemoController> _logger;

        public const int RecordsPerPage = 20;
        public List<Project> ProjectData;

        public LazyLoadComboDemoController(ILogger<LazyLoadComboDemoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            LazyLoadComboDemoModel model = new LazyLoadComboDemoModel();
            ViewBag.RecordsPerPage = RecordsPerPage;
            return View(model);
        }

        public JsonResult GetProjects(int? pageNum)
        {
            LazyLoadComboDemoModel model = new LazyLoadComboDemoModel();
            model.PageNum = pageNum.GetValueOrDefault();
            return Json(model.ProjectSelectList);
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}