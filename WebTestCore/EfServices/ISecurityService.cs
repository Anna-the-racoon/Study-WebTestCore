using WebTestCore.Models.Security;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebInterface.EfServices
{
    public interface ISecurityService
    {
        public Task<int> Authorization(SecurityVm security);

        public Task<SecurityVm> Authorization(int id);

        public Task<SecurityListVm> GetList();

        public Task Create(SecurityCreateVm security);

        public Task<SecurityUpdateVm> GetUpdate(int id);
        public Task Update(SecurityUpdateVm security);

        public Task<SecurityDeleteVm> GetDelete(int id);

        public Task Delete(SecurityDeleteVm security);

        public string CheckList(string login);

    }
}
