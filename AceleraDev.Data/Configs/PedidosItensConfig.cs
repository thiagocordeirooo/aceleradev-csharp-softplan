using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceleraDev.Data.Configs
{
    public class PedidosItensConfig : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("pedido_item");

            builder.HasKey(p => new { p.PedidoId, p.ProdutoId });

            builder.Property(p => p.PedidoId).HasColumnName("PedidoId").IsRequired();
            builder.Property(p => p.ProdutoId).HasColumnName("ProdutoId").IsRequired();

            builder.HasOne(p => p.Produto);
            builder.HasOne(p => p.Pedido);
        }
    }
}
