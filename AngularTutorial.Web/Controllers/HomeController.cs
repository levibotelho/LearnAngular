using System;
using System.Web.Mvc;
using System.Web.UI;
using AngularTutorial.Services;

namespace AngularTutorial.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc.Html;
    using AngularTutorial.Entities;

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
        public ActionResult Index(string _escaped_fragment_)
        {
            if (_escaped_fragment_ != null)
            {
                string lessonId = null;
                if (_escaped_fragment_.Trim() == string.Empty)
                {
                    lessonId = _courseService.GetTableOfContents().Modules[0].Children[0].Id;
                }
                else if (_escaped_fragment_.Contains("lessons"))
                {
                    var lessonIdStartIndex = _escaped_fragment_.LastIndexOf('/') + 1;
                    lessonId = _escaped_fragment_.Substring(lessonIdStartIndex, _escaped_fragment_.Length - lessonIdStartIndex);
                }

                ViewBag.SeoContent = new MvcHtmlString(_courseService.GetLesson(lessonId).Instructions);
            }

            return View();
        }

        [HttpGet]
#if !DEBUG
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Any)]
#endif
        public JsonResult GetTableOfContents()
        {
            var modules = _courseService.GetTableOfContents().Modules;
            var simplifiedTableOfContents = modules.Select(module => new
            {
                module.Id,
                module.Title,
                Lessons = module.Children.Select(lesson => new
                {
                    lesson.Id,
                    lesson.Title,
                    ModuleId = module.Id
                }).ToArray()
            }).ToArray();
            return Json(simplifiedTableOfContents, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
#if !DEBUG
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Any, VaryByParam = "*")]
#endif
        public JsonResult GetLesson(string id)
        {
            var lessonId = string.IsNullOrWhiteSpace(id) ? _courseService.GetTableOfContents().Modules[0].Children[0].Id : id;
            var lesson = _courseService.GetLesson(lessonId);
            return Json(lesson, JsonRequestBehavior.AllowGet);
        }
    }
}