using System;

namespace AceleraDev.Domain.Models
{
    public class PedidoItem
    {
        public Guid PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public Guid ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        public decimal ValorTotalItem
        {
            get
            {
                return Quantidade * ValorUnitario;
            }
        }
    }
}
