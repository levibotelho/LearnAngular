using System.Web.Mvc;

namespace AngularTutorial.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
	}
}