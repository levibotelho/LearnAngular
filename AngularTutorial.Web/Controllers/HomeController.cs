using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularTutorial.Services;
#if !DEBUG
using System.Web.UI;
#endif
using Spoon.Standalone.Connector;

namespace AngularTutorial.Web.Controllers
{
    using System.Net.Http;
    using System.Threading.Tasks;

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
        public async Task<ActionResult> Index(string _escaped_fragment_)
        {
            if (_escaped_fragment_ == null)
                return View();

            try
            {
                return await SnapshotManager.GetSnapshotAsync(
                    _escaped_fragment_,
                    ConfigurationFacade.SpoonSnapshotStorageAccount,
                    ConfigurationFacade.SpoonSnapshotStorageContainer);
            }
            catch (HttpRequestException)
            {
                throw new HttpException(404, "The requested snapshot could not be found.");
            }
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

        static string GetSnapshotUrl(string escapedFragment)
        {
            return string.Format(
                "http://{0}.blob.core.windows.net/{1}/_escaped_fragment_={2}.html",
                ConfigurationFacade.SpoonSnapshotStorageAccount,
                ConfigurationFacade.SpoonSnapshotStorageContainer,
                escapedFragment);
        }

        async Task<ViewResult> SnapshotContentAsync(string escapedFragment)
        {
            var blobUrl = GetSnapshotUrl(escapedFragment);
            using (var client = new HttpClient())
            {
                ViewBag.Content = await client.GetStringAsync(blobUrl);
                return View("EscapedFragment");
            }
        }
    }
}