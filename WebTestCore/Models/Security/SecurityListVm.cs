using System.Collections.Generic;

namespace WebTestCore.Models.Security
{
    public class SecurityListVm
    {
        public int Id { get; set; }

        public List<SecurityList> SecurityList { get; set; }

    }

    public class SecurityList
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
