using AceleraDev.CrossCutting.Exceptions;
using AceleraDev.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace AceleraDev.Domain.Models
{
    public class Cliente: ModelBase
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
        public List<Endereco> Enderecos { get; set; }

        public bool Valido()
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                throw new ModelValidationException("O campo Nome é obrigatório.");
            }

            return true;
        }
    }
}
