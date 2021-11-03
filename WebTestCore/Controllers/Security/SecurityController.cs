using Microsoft.AspNetCore.Mvc;
using WebInterface.EfServices;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index(SecurityVm security)
        {
            if (!ModelState.IsValid) return View("Index");

            var actualId = await _dbService.Authorization(security);

            return actualId != 0 ? View("Result", security) : View("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> Result(int? id)
        {
            if (id == null) return View("Index");

            var result = new EfSecurityServices();
            var security = await result.Authorization((int)id);

            return View("Result", security);
        }

        public async Task<IActionResult> List() 
        {
            var list = await _dbService.GetList();
            //HttpClient 
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SecurityCreateVm security)
        {
            if (!ModelState.IsValid) return View("Create");

            if (security.Password.Length < 3) return View("Create");

            await _dbService.Create(security);

            return View("List", await _dbService.GetList());
        }
        
        [HttpPost]
        public JsonResult Ajax(string login)
        {
            var json = _dbService.CheckList(login);
            return Json(json);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return View("Index");

            var security = await _dbService.GetUpdate((int)id);

            return View(security);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SecurityUpdateVm security)
        {
            if (!ModelState.IsValid) return View("Index");

            await _dbService.Update(security);

            return View("List", await _dbService.GetList());
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return View("Index");

            var security = await _dbService.GetDelete((int)id);

            return View(security);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SecurityDeleteVm security)
        {
            if (!ModelState.IsValid) return View("Index");

            await _dbService.Delete(security);

            return View("List", await _dbService.GetList());
        }
    }
}
