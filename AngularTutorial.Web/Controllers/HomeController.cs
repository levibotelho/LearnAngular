using System;
using System.Web.Mvc;
using AngularTutorial.Services;
using AngularTutorial.Web.Models.Home;

namespace AngularTutorial.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ICourseService _courseService;

        public HomeController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexModel(_courseService.GetTableOfContents().Modules);
            return View(model);
        }

        [HttpGet]
        public JsonResult GetStep(Guid id)
        {
            var step = _courseService.GetStep(id);
            return Json(step, JsonRequestBehavior.AllowGet);
        }
	}
}