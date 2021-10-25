using System.Collections.Generic;
using WebTestCore.Models.Security;

namespace WebInterface.EfServices
{
    public interface ISecurityService
    {
        public int Authorization(SecurityVm security);

        public SecurityVm Authorization(int id);

        public SecurityListVm GetList(int id);

        public void Create(SecurityCreateVm security);

        public SecurityUpdateVm GetUpdate(int id);

        public void Update(SecurityUpdateVm security);

        public SecurityDeleteVm GetDelete(int id);

        public void Delete(SecurityDeleteVm security);

    }
}
