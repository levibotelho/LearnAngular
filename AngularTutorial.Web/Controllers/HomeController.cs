using System.Linq;
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
            var model = new IndexModel
            {
                ModuleNames = _courseService.TableOfContents.Modules.Keys.ToArray(),
            };

            return View(model);
        }
	}
}