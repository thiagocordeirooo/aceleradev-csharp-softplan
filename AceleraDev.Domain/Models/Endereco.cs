using AceleraDev.Domain.Models.Base;

namespace AceleraDev.Domain.Models
{
    public class Endereco: ModelBase
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
    }
}