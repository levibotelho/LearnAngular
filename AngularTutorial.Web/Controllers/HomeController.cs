using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using AngularTutorial.Services;
using AngularTutorial.Web.Entities;

namespace AngularTutorial.Web.Controllers
{
    public class HomeController : AsyncController
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
        // ReSharper disable once InconsistentNaming
        public ActionResult Index(string _escaped_fragment_)
        {
            return _escaped_fragment_ == null ? (ActionResult)View() : Redirect(GetSnapshotUrl(_escaped_fragment_));
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

        [HttpPost]
        public void SendFeedback(string subject, string message)
        {
            Feedback.SendMessage(subject, message);
        }

        static string GetSnapshotUrl(string escapedFragment)
        {
            return string.Format(
                "http://{0}.blob.core.windows.net/{1}/_escaped_fragment={2}.html",
                ConfigurationFacade.SpoonSnapshotStorageAccount,
                ConfigurationFacade.SpoonSnapshotStorageContainer,
                escapedFragment);
        }
    }
}