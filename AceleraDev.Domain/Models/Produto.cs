using AceleraDev.Domain.Models.Base;

namespace AceleraDev.Domain.Models
{
    public class Produto : ModelBase
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
