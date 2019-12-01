using System.ComponentModel.DataAnnotations;

namespace AceleraDev.Application.ViewModels.Autenticacao
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Login { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

    }
}
