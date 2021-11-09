using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Security
{
    public class SecurityModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
