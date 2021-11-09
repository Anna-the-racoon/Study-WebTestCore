using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Web.Http.Description;

namespace WebApi.Models.Security.Security
{
    public class SecurityUpdate
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Длина пароля не может быть меньше 3 символов")]
        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
}
