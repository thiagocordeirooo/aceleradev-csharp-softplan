using AceleraDev.Domain.Models.Base;

namespace AceleraDev.Domain.Models
{
    public class Usuario: ModelBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
    }
}
