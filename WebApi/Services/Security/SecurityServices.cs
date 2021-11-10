using Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestCore.Models.Security;

namespace WebApi.Services.Security
{
    public class SecurityServices
    {
        public SecurityList List() 
        {
            var context = new TestDbContext();

            var security = context.Security
                .ToList();

            var models = new SecurityList()
            {
            };

            return models;
        }

    }
}
