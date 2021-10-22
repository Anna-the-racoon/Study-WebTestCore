using Database.Context;
using WebTestCore.Models.Security;

namespace Business_Logic.Security
{
    public class SecurityLogic
    {
        public void CreateSecurity(SecurityVm security)
        {
            var context = new TestDbContext();

            var newSecurity = new Database.Models.Securities.Security()
            {
                Login = security.Login,
                Password = security.Password,
            };

            context.Security.Add(newSecurity);
            context.SaveChanges();
        }

    }
}
