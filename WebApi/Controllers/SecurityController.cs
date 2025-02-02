﻿using Database.Context;
using Database.Models.Securities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Security.Security;
using WebApi.Services.Security;
using WebTestCore.Models.Security;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetList()
        {
            var context = new TestDbContext();

            var security = await context.Security
                .ToListAsync();

            var models = new List<SecurityList>();

            foreach (var item in security)
            {
                var element = new SecurityList()
                {
                    Id = item.Id,
                    Login = item.Login,
                    Password = item.Password,
                };

                models.Add(element);
            }

            var json = JsonConvert.SerializeObject(models);

            return json;
        }

        [HttpGet("GetId")]
        public async Task<ActionResult<SecurityList>> GetId(int? id)
        {
            if (id == null) return BadRequest();

            var context = new TestDbContext();

            var security = await context.Security
                .SingleOrDefaultAsync(p => p.Id == (int)id);

            if (security == null) return BadRequest();

            var model = new SecurityList()
            {
                Id = security.Id,
                Login = security.Login,
                Password = security.Password,
            };

            return model;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(string login, string password)
        {
            if (login == null || password == null) return BadRequest();

            login = login.Trim();
            password = password.Trim();

            var context = new TestDbContext();

            var actualLogin = context.Security
                .Select(p => p.Login)
                .Contains(login);

            if (actualLogin) return BadRequest();

            var newSecurity = new Security()
            {
                Login = login,
                Password = password,
            };

            await context.Security.AddAsync(newSecurity);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(int? id, string login, string password)
        {
            if (id == null || login == null || password == null) 
                return BadRequest();

            var context = new TestDbContext();

            var actualLogin = await context.Security
                .SingleOrDefaultAsync(p => p.Id == (int) id);

            if (actualLogin.Login.Trim() == login &&
                actualLogin.Password.Trim() == password)
                return BadRequest();

            if (context.Security
                .Where(p => p.Id != id)
                .Select(p => p.Login)
                .Contains(login))
                return BadRequest();

            actualLogin.Login = login;
            actualLogin.Password = password;

            context.Security.Update(actualLogin);
            context.SaveChanges();

            return Ok();
        }

        [HttpPost("updateJson")]
        public async Task<ActionResult> UpdateJson([FromBody]SecurityUpdate security)
        {
            if (security == null) return BadRequest();

            var context = new TestDbContext();

            var actualLogin = await context.Security
                .SingleOrDefaultAsync(p => p.Id == security.Id);

            if (actualLogin.Login.Trim() == security.Login &&
                actualLogin.Password.Trim() == security.Password)
                return BadRequest();

            if (context.Security
                .Where(p => p.Id != security.Id)
                .Select(p => p.Login)
                .Contains(security.Login))
                return BadRequest();

            actualLogin.Login = security.Login;
            actualLogin.Password = security.Password;

            context.Security.Update(actualLogin);
            context.SaveChanges();

            return Ok("Success");
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var context = new TestDbContext();

            var actualLogin = await context.Security
                .SingleOrDefaultAsync(p => p.Id == (int)id);

            if (actualLogin == null) return BadRequest();

            context.Security.Remove(actualLogin);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
