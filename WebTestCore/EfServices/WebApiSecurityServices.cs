using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public async Task Create(SecurityCreateVm security)
        {
            var service = new HttpClient();

            var content = new StringContent("", Encoding.UTF8, "text/plain");

            await service.PostAsync($"http://localhost:5001/api/security/create?Login={security.Login}&Password={security.Password}", content);
        }

        public async Task Delete(SecurityDeleteVm security)
        {
            var service = new HttpClient();

            await service.DeleteAsync($"http://localhost:5001/api/security/delete?Id={security.Id}");
        }

        public async Task<SecurityDeleteVm> GetDelete(int id)
        {
            var service = new HttpClient();

            var url = $"http://localhost:5001/api/security/GetId?id={id}";

            var getObject = await service.GetStringAsync(url);

            var security = JsonConvert.DeserializeObject<SecurityDeleteVm>(getObject);

            return security;
        }

        public async Task<SecurityListVm> GetList()
        {
            var service = new HttpClient();

            var securityList = await service.GetStringAsync("http://localhost:5001/api/security");

            var list = JsonConvert.DeserializeObject<List<SecurityList>>(securityList);

            var model = new SecurityListVm()
            {
                SecurityList = list,
            };

            return model;
        }

        public async Task<SecurityUpdateVm> GetUpdate(int id)
        {
            var service = new HttpClient();

            var url = $"http://localhost:5001/api/security/GetId?id={id}";
                
            var getObject = await service.GetStringAsync(url);

            var security = JsonConvert.DeserializeObject<SecurityUpdateVm>(getObject);

            return security;
        }

        public async Task Update(SecurityUpdateVm security)
        {
            var service = new HttpClient();

            var json = new StringContent(JsonConvert.SerializeObject(security), Encoding.UTF8, "application/json");

            await service.PostAsync(("http://localhost:5001/api/security/updateJson"), json);
        }
    }
}