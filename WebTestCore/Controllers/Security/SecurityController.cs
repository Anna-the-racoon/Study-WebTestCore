using Database.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebInterface.EfServices;

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

            var result = new SecurityServices();
            var actualId = result.Authorization(security);

            return actualId != null ? View("Result", security) : View("Index");
        }
        
        [HttpPost]
        public IActionResult Result(int? id)
        {
            if (id == null) return View("Index");

            var result = new SecurityServices();
            var security = result.Authorization((int)id);

            return View("Result", security);
        }

        [HttpGet]
        public IActionResult List(SecurityListVm security) 
        {
            if (security == null) return View("Index");

            var result = new SecurityServices();
            var list = result.GetList(security.Id);

            return View(list);
        }

        [HttpPost]
        public IActionResult List(int? id) 
        {
            if (id == null) return View("Index");

            var result = new SecurityServices();
            var current = result.BackList((int)id);

            return View(current);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SecurityCreateVm security)
        {
            if (!ModelState.IsValid) return View("Create");

            if (security.Password.Length < 3) return View("Create");

            var result = new SecurityServices();
            result.Create(security);

            return View("Index", null);     //View("Create")
        }
        
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null) return View("Index");

            var result = new SecurityServices();
            var security = result.GetUpdate((int)id);

            return View(security);
        }

        [HttpPost]
        public IActionResult Update(SecurityUpdateVm security)
        {
            if (!ModelState.IsValid) return View("Index");

            var result = new SecurityServices();
            result.Update(security);

            return View("Index");
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return View("Index");

            var result = new SecurityServices();
            var security = result.GetDelete((int)id);

            return View(security);
        }

        [HttpPost]
        public IActionResult Delete(SecurityDeleteVm security)
        {
            if (!ModelState.IsValid) return View("Index");
            
            var result = new SecurityServices();
            result.Delete(security);

            return View("Index");
        }
    }
}
