using Microsoft.AspNetCore.Mvc;

namespace WebTestCore.Models.Security
{
    public class SecurityController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SecurityVm security)
        {
            if (!ModelState.IsValid) return View("Index");

            //var security = new SecurityVm()
            //{
            //    Login = model.Login,
            //    Password = model.Password
            //};

            return View("Result", security);
        }
    }
}
