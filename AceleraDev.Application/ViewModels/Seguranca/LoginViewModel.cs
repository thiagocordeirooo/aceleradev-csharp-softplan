using System.ComponentModel.DataAnnotations;

namespace AceleraDev.Application.ViewModels.Seguranca
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }
    }
}
