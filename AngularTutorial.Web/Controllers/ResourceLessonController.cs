using System.Web.Mvc;

namespace AngularTutorial.Web.Controllers
{
    public class ResourceLessonController : Controller
    {
        [HttpGet]
        public JsonResult Users(int id)
        {
            return id == 1 ? Json(GetUser(), JsonRequestBehavior.AllowGet) : null;
        }

        [HttpPost]
        public JsonResult Users(User user)
        {
            if (user.id == 1)
            {
                SetUser(user);
                return Json(true);
            }

            return Json(false);
        }

        User GetUser()
        {
            return (User)(Session["ResourceLesson.User"] ?? (Session["ResourceLesson.User"] = new User()));
        }

        void SetUser(User user)
        {
            Session["ResourceLesson.User"] = user;
        }
	}

    public class User
    {
        public User()
        {
            id = 1;
            name = "John Doe";
            email = "jdoe@example.com";
        }

        // ReSharper disable InconsistentNaming
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        // ReSharper restore InconsistentNaming
    }
}