using System;
using System.Collections.Generic;

namespace AceleraDev.Application.ViewModels
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public bool Ativo { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public List<string> Telefones { get; set; }
    }
}
