using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebTestCore.Models.Security
{
    public class SecurityListVm
    {
        [JsonPropertyName("GetSecurityList")]
        public List<SecurityList> SecurityList { get; set; }
    }

    public class SecurityList
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
