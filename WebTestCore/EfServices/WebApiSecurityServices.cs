using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestCore.Models.Security;

namespace WebInterface.EfServices
{
    public class WebApiSecurityServices : ISecurityService
    {
        public Task<int> Authorization(SecurityVm security)
        {
            throw new NotImplementedException();
        }

        public Task<SecurityVm> Authorization(int id)
        {
            throw new NotImplementedException();
        }

        public string CheckList(string login)
        {
            throw new NotImplementedException();
        }

        public Task Create(SecurityCreateVm security)
        {
            throw new NotImplementedException();
        }

        public Task Delete(SecurityDeleteVm security)
        {
            throw new NotImplementedException();
        }

        public Task<SecurityDeleteVm> GetDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SecurityListVm> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<SecurityUpdateVm> GetUpdate(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(SecurityUpdateVm security)
        {
            throw new NotImplementedException();
        }
    }
}
