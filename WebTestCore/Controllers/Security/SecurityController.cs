using Microsoft.AspNetCore.Mvc;

namespace WebTestCore.Models.Security
{
    public class SecurityController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Login, string Password)
        {
            if (!ModelState.IsValid) return View("Index");

            var security = new SecurityVm()
            {
                Login = Login,
                Password = Password
            };

            return View("Result", security);
        }


        [HttpPost]
        [ActionName("Submit")]
        public ActionResult Result()
        {
            return View("Result", new SecurityVm() { Login = "1", Password = "10" });
        }
    }
}
