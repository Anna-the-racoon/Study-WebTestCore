using Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using WebTestCore.Models.Security;


namespace WebInterface.EfServices
{
    public class SecurityServices : ISecurityService
    {
        public int Authorization(SecurityVm security)
        {
            var context = new TestDbContext();

            var actualLogin = context.Security
                .Where(p => p.Login.Contains(security.Login))
                .SingleOrDefault(p => p.Password.Contains(security.Password));

            security.Id = actualLogin.Id;

            return security.Id;
        }
        public SecurityVm Authorization(int id)
        {
            var context = new TestDbContext();

            var actualLogin = context.Security
                .SingleOrDefault(p => p.Id == id);

            var security = new SecurityVm()
            {
                Id = actualLogin.Id,
                Login = actualLogin.Login,
                Password = actualLogin.Password,
            };

            return security;
        }

        public SecurityListVm GetList(int id)
        {
            var context = new TestDbContext();

            var security = context.Security
                .ToList();

            var model = new SecurityListVm()
            {
                Id = id,
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

        public SecurityVm BackList(int id)
        {
            var context = new TestDbContext();

            var actualLogin = context.Security
                .SingleOrDefault(p => p.Id == id);

            var security = new SecurityVm()
            {
                Id = actualLogin.Id,
                Login = actualLogin.Login,
                Password = actualLogin.Password,
            };

            return security;

        }

        public void Create(SecurityCreateVm security)
        {
            var context = new TestDbContext();

            var actualLogin = context.Security
                .Select(p => p.Login)
                .Contains(security.Login);

            if (actualLogin) return;

            var newSecurity = new Database.Models.Securities.Security()
            {
                Login = security.Login.Trim(),
                Password = security.Password.Trim(),
            };

            context.Security.Add(newSecurity);
            context.SaveChanges();
        }

        public SecurityUpdateVm GetUpdate(int id)
        {
            var context = new TestDbContext();

            var actualLogin = context.Security
                .SingleOrDefault(p => p.Id == id);

            var current = new SecurityUpdateVm()
            {
                Id = actualLogin.Id,
                Login = actualLogin.Login,
                Password = actualLogin.Password,
            };

            return current;
        }
        public void Update(SecurityUpdateVm security)
        {
            var context = new TestDbContext();

            var actualLogin = context.Security
                .SingleOrDefault(p => p.Id == security.Id);

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

        public SecurityDeleteVm GetDelete(int id)
        {
            var context = new TestDbContext();

            var actualLogin = context.Security
                .SingleOrDefault(p => p.Id == id);

            var current = new SecurityDeleteVm()
            {
                Id = actualLogin.Id,
                Login = actualLogin.Login,
                Password = actualLogin.Password,
            };

            return current;
        }

        public void Delete(SecurityDeleteVm security)
        {
            var context = new TestDbContext();

            var actualLogin = context.Security
                .SingleOrDefault(p => p.Id == security.Id);

            context.Security.Remove(actualLogin);
            context.SaveChanges();
        }

    }
}
