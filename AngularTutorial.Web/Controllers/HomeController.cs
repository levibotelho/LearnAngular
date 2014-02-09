using System;
using System.Web.Mvc;
using AngularTutorial.Entities;
using AngularTutorial.Services;
using AngularTutorial.Web.Models.Home;

namespace AngularTutorial.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ICurriculumService _curriculumService;

        public HomeController(ICurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexModel(_curriculumService.GetTableOfContents().GetModules());
            return View(model);
        }

        [HttpGet]
        public JsonResult GetStep(Guid id)
        {
            var step = _curriculumService.GetStep(id);
            return Json(step, JsonRequestBehavior.AllowGet);
        }
	}
}