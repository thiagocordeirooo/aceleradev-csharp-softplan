using AceleraDev.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AceleraDev.Domain.Models
{
    public class Pedido : ModelBase
    {
        public long Numero { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<PedidoItem> Itens { get; set; }

        public decimal ValorTotal
        {
            get
            {
                return Itens.Sum(p => p.ValorTotalItem);
            }
        }

        public Pedido()
        {
            Numero = DateTime.Now.Ticks;
            Itens = new List<PedidoItem>();
        }

        public Pedido(Cliente cliente) : this()
        {
            Cliente = cliente;
        }

        public Pedido(Cliente cliente, List<PedidoItem> itens) : this(cliente)
        {
            Itens = itens;
        }
    }
}
