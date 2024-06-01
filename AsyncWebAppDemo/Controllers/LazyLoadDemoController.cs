using AsyncWebAppDemo.Models;
using AsyncWebAppDemo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsyncWebAppDemo.Controllers
{
    public class LazyLoadDemoController : Controller
    {
        private readonly ILogger<LazyLoadDemoController> _logger;

        public const int RecordsPerPage = 20;
        public List<Project> ProjectData;

        public LazyLoadDemoController(ILogger<LazyLoadDemoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            LazyLoadDemoModel model = new LazyLoadDemoModel();
            ViewBag.RecordsPerPage = RecordsPerPage;
            return View(model);
        }

        public ActionResult GetProjects(int? pageNum)
        {
            LazyLoadDemoModel model = new LazyLoadDemoModel();
            model.PageNum = pageNum.GetValueOrDefault();
            return PartialView("Index\\_ProjectData", model.ProjectList);
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}