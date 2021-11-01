using Microsoft.AspNetCore.Mvc;
using WebInterface.EfServices;

namespace WebTestCore.Models.Security
{
    public class SecurityController : Controller
    {
        public ISecurityService _dbService;

        public SecurityController(ISecurityService securityService)
        {
            _dbService = securityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SecurityVm security)
        {
            if (!ModelState.IsValid) return View("Index");

            var actualId = _dbService.Authorization(security);

            return actualId != 0 ? View("Result", security) : View("Index");
        }
        
        [HttpPost]
        public IActionResult Result(int? id)
        {
            if (id == null) return View("Index");

            var result = new EfSecurityServices();
            var security = result.Authorization((int)id);

            return View("Result", security);
        }

        public IActionResult List() 
        {
            var list = _dbService.GetList();

            return View(list);
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

            _dbService.Create(security);

            return View("List", _dbService.GetList());
        }
        
        [HttpPost]
        public JsonResult Ajax(string login)
        {
            var json = _dbService.CheckList(login);
            return Json(json);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null) return View("Index");

            var security = _dbService.GetUpdate((int)id);

            return View(security);
        }

        [HttpPost]
        public IActionResult Update(SecurityUpdateVm security)
        {
            if (!ModelState.IsValid) return View("Index");

            _dbService.Update(security);

            return View("List", _dbService.GetList());
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return View("Index");

            var security = _dbService.GetDelete((int)id);

            return View(security);
        }

        [HttpPost]
        public IActionResult Delete(SecurityDeleteVm security)
        {
            if (!ModelState.IsValid) return View("Index");

            _dbService.Delete(security);

            return View("List", _dbService.GetList());
        }
    }
}
