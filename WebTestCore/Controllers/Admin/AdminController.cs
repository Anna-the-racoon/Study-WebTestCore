using Microsoft.AspNetCore.Mvc;

namespace WebTestCore.Controllers.Admin
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
