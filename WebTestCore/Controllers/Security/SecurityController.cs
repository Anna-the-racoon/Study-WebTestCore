using Microsoft.AspNetCore.Mvc;
using Database.Context;
using System.Linq;

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

            var context = new TestDbContext();

            var actualLogin = context.Security
                .Where(p => p.Login.Contains(security.Login))
                .SingleOrDefault(p => p.Password.Contains(security.Password));

            security.Id = actualLogin?.Id ?? -1;

            return actualLogin != null ? View("Result", security) : View("Index");
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

            var context = new TestDbContext();

            var actualLogin = context.Security
                .Select(p=>p.Login)
                .Contains(security.Login);

            if (actualLogin) return View("Create");


            var newSecurity = new Database.Models.Securities.Security()
            {
                Login = security.Login.Trim(),
                Password = security.Password.Trim(),
            };

            context.Security.Add(newSecurity);
            context.SaveChanges();

            return View("Index", null);
        }
        
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null) return View("Index");

            var context = new TestDbContext();
            
            var actualLogin = context.Security
                .SingleOrDefault(p => p.Id == id);

            var current = new SecurityUpdateVm()
            {
                Id = actualLogin.Id,
                Login = actualLogin.Login,
                Password = actualLogin.Password,
            };

            return View(current);
        }

        [HttpPost]
        public IActionResult Update(SecurityUpdateVm security)
        {
            if (!ModelState.IsValid) return View("Index");

            var context = new TestDbContext();

            var actualLogin = context.Security
                .SingleOrDefault(p => p.Id == security.Id);

            if (actualLogin.Login.ToString().Trim() == security.Login.ToString() && 
                actualLogin.Password.ToString().Trim() == security.Password.ToString()) 
                return View("Result", security);

            if (context.Security
                .Where(p => p.Id != security.Id)
                .Select(p => p.Login)
                .Contains(security.Login))
                return View("Update", actualLogin);

            actualLogin.Login = security.Login;
            actualLogin.Password = security.Password;

            context.Security.Update(actualLogin);
            context.SaveChanges();

            return View("Index");
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return View("Index");

            var context = new TestDbContext();

            var actualLogin = context.Security
                .SingleOrDefault(p => p.Id == id);

            var current = new SecurityDeleteVm()
            {
                Id = actualLogin.Id,
                Login = actualLogin.Login,
                Password = actualLogin.Password,
            };

            return View(current);
        }

        [HttpPost]
        public IActionResult Delete(SecurityDeleteVm security)
        {
            if (!ModelState.IsValid) return View("Index");

            var context = new TestDbContext();

            var actualLogin = context.Security
                .SingleOrDefault(p => p.Id == security.Id);

            context.Security.Remove(actualLogin);
            context.SaveChanges();

            return View("Index");
        }
    }
}
