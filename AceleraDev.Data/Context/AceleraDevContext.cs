using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AceleraDev.Data.Context
{
    public class AceleraDevContext : DbContext
    {
        public AceleraDevContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null) property.SetMaxLength(255);
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
            {
                if (property.GetColumnType() == null) property.SetColumnType("decimal(18, 4)");
            }

            // modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AceleraDevContext).Assembly);


            modelBuilder.Entity<Cliente>().HasData(new Cliente { Nome = "Thiago" });
        }
    }
}
