using System.ComponentModel.DataAnnotations;

namespace Database.Models.Securities
{
    public class Security
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        //public int UserId { get; set; }
        public User UserName { get; set; }

    }
}
