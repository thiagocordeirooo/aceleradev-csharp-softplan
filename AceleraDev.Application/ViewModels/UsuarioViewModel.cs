using System;
using System.Text.Json.Serialization;

namespace AceleraDev.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid? Id { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public bool Ativo { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Senha { get; set; }
        public string Perfil { get; set; }

        public string AccessToken { get; set; }
    }
}
