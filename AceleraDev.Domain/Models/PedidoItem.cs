namespace AceleraDev.Domain.Models
{
    public class PedidoItem
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotalItem
        {
            get
            {
                return Quantidade * Produto.Valor;
            }
        }
    }
}
