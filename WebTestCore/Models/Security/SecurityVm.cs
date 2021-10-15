using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebTestCore.Models.Security
{
    public class SecurityVm
    {
        [DisplayName("Login")]
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Длина пароля не может быть меньше 3 символов")]
        [Compare("Login", ErrorMessage = "Пароль не может совпадать с логином")]
        public string Password { get; set; }

    }
}
