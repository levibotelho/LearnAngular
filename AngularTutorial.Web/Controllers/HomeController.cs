using System;
using System.Web.Mvc;
using System.Web.UI;
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
#if !DEBUG
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Any)]
#endif
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
#if !DEBUG
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Any)]
#endif
        public JsonResult GetTableOfContents()
        {
            return Json(_courseService.GetTableOfContents().Modules, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
#if !DEBUG
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Any, VaryByParam = "*")]
#endif
        public JsonResult GetStep(Guid id)
        {
            var step = _courseService.GetStep(id);
            return Json(step, JsonRequestBehavior.AllowGet);
        }
	}
}