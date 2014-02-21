using System;
using System.Web.Mvc;
using AngularTutorial.Services;

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
            return View();
        }

        [HttpGet]
        public JsonResult GetTableOfContents()
        {
            return Json(_courseService.GetTableOfContents().Modules, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetStep(Guid id)
        {
            var step = _courseService.GetStep(id);
            return Json(step, JsonRequestBehavior.AllowGet);
        }
	}
}