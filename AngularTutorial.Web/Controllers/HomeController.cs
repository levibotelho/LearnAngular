using System.IO;
using System.Linq;
using System.Web.Mvc;
using AngularTutorial.Services;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Index(string _escaped_fragment_)
        {
            if (_escaped_fragment_ != null)
                await HandleEscapedFragmentAsync(_escaped_fragment_);

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

        async Task HandleEscapedFragmentAsync(string escapedFragment)
        {
            if (escapedFragment.Trim() == string.Empty)
            {
                var lessonId = _courseService.GetTableOfContents().Modules[0].Children[0].Id;
                ViewBag.SeoContent = new MvcHtmlString(_courseService.GetLesson(lessonId).Instructions);
            }
            else if (escapedFragment.Contains("lessons"))
            {
                var lessonIdStartIndex = escapedFragment.LastIndexOf('/') + 1;
                var lessonId = escapedFragment.Substring(lessonIdStartIndex, escapedFragment.Length - lessonIdStartIndex);
                ViewBag.SeoContent = new MvcHtmlString(_courseService.GetLesson(lessonId).Instructions);
            }
            else if (escapedFragment.Contains("about"))
            {
                var aboutPath = Server.MapPath("~/Content/Views/About.html");
                string aboutText;
                using (var sr = new StreamReader(aboutPath))
                {
                    aboutText = await sr.ReadToEndAsync();
                }

                ViewBag.SeoContent = new MvcHtmlString(aboutText);
            }
        }
    }
}