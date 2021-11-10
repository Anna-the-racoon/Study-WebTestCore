using Database.Context;
using Database.Models.Securities;
using Newtonsoft.Json;
using System;
using System.Linq;
using WebTestCore.Models.Security;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebInterface.EfServices
{
    public class EfSecurityServices //: ISecurityService
    {
        public async Task<int> Authorization(SecurityVm security)
        {
            var context = new TestDbContext();

            var actualLogin = await context.Security
                .Where(p => p.Login.Contains(security.Login))
                .SingleOrDefaultAsync(p => p.Password.Contains(security.Password));

            security.Id = actualLogin.Id;

            return security.Id;
        }
        
        public async Task<SecurityVm> Authorization(int id)
        {
            var context = new TestDbContext();

            var actualLogin = await context.Security
                .SingleOrDefaultAsync(p => p.Id == id);

            var security = new SecurityVm()
            {
                Id = actualLogin.Id,
                Login = actualLogin.Login,
                Password = actualLogin.Password,
            };

            return security;
        }

        public async Task<SecurityListVm> GetList()
        {
            var context = new TestDbContext();

            var security = await context.Security
                .ToListAsync();

            var model = new SecurityListVm()
            {
                SecurityList = security.Select( list => new SecurityList()
                {
                    Id = list.Id,
                    Login = list.Login,
                    Password = list.Password,
                })
                .ToList(),
            };

            return model;
        }

        public async Task Create(SecurityCreateVm security)
        {
            var context = new TestDbContext();

            var actualLogin = context.Security
                .Select(p => p.Login)
                .Contains(security.Login);

            if (actualLogin) return;

            var newSecurity = new Security()
            {
                Login = security.Login.Trim(),
                Password = security.Password.Trim(),
            };

            await context.Security.AddAsync(newSecurity);
            await context.SaveChangesAsync();
        }

        public async Task<SecurityUpdateVm> GetUpdate(int id)
        {
            var context = new TestDbContext();

            var actualLogin = await context.Security
                .SingleOrDefaultAsync(p => p.Id == id);

            var current = new SecurityUpdateVm()
            {
                Id = actualLogin.Id,
                Login = actualLogin.Login,
                Password = actualLogin.Password,
            };

            return current;
        }

        public async Task Update(SecurityUpdateVm security)
        {
            var context = new TestDbContext();

            var actualLogin = await context.Security
                .SingleOrDefaultAsync(p => p.Id == security.Id);

            if (actualLogin.Login.ToString().Trim() == security.Login.ToString() &&
                actualLogin.Password.ToString().Trim() == security.Password.ToString())
                return;

            if (context.Security
                .Where(p => p.Id != security.Id)
                .Select(p => p.Login)
                .Contains(security.Login))
                return;

            actualLogin.Login = security.Login;
            actualLogin.Password = security.Password;

            context.Security.Update(actualLogin);
            context.SaveChanges();
        }

        public async Task<SecurityDeleteVm> GetDelete(int id)
        {
            var context = new TestDbContext();

            var actualLogin = await context.Security
                .SingleOrDefaultAsync(p => p.Id == id);

            var current = new SecurityDeleteVm()
            {
                Id = actualLogin.Id,
                Login = actualLogin.Login,
                Password = actualLogin.Password,
            };

            return current;
        }

        public async Task Delete(SecurityDeleteVm security)
        {
            var context = new TestDbContext();

            var actualLogin = await context.Security
                .SingleOrDefaultAsync(p => p.Id == security.Id);

            context.Security.Remove(actualLogin);
            await context.SaveChangesAsync();
        }

        #region Work with JSON
        public string CheckList(string login)
        {
            var context = new TestDbContext();

            var checkLogin = context.Security
                .SingleOrDefault(p=>p.Login == login);

            var element = checkLogin == null ? null : MakeJson(checkLogin);

            return element;
        }
        
        public static string MakeJson(Security securityData)
        {
            var json = JsonConvert.SerializeObject(securityData);

            return json;
        }
        #endregion
    }
}
