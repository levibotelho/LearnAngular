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
            var model = new IndexModel(_curriculumService.GetTableOfContents().ModuleNames[Language.English]);
            return View(model);
        }
	}
}