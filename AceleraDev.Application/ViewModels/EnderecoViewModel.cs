using System;
using System.Collections.Generic;
using System.Text;

namespace AceleraDev.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public Guid? Id { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public bool Ativo { get; set; }

        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
