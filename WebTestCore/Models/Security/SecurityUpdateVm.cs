using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebTestCore.Models.Security
{
    public class SecurityUpdateVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Длина пароля не может быть меньше 3 символов")]
        public string Password { get; set; }

    }
}
