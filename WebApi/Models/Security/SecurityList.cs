using System.Collections.Generic;

namespace WebTestCore.Models.Security
{
    public class SecurityList
    {
        public List<SecuritiesList> GetSecurityList { get; set; }
    }

    public class SecuritiesList
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
