using System.ComponentModel.DataAnnotations;
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
            if (!ModelState.IsValid)
                return Json(null);

            SetUser(user);
            return Json(user);
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
        [Range(1, 1)]
        public int id { get; set; }
        [MaxLength(40)]
        public string name { get; set; }
        [MaxLength(40)]
        public string email { get; set; }
        // ReSharper restore InconsistentNaming
    }
}