using AceleraDev.CrossCutting.CustomValitators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AceleraDev.Application.ViewModels
{
    public class ClienteViewModel
    {
        public Guid? Id { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public bool Ativo { get; set; }
        
        //[Required(ErrorMessage = "Preciso do CPF para Cadastro. Te vira!!")]
        //[CPF]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Sobrenome { get; set; }

        public DateTime? DataNascimento { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        [RegularExpression(@"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$", ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        public List<EnderecoViewModel> Enderecos { get; set; }
    }
}
