using AceleraDev.CrossCutting.Constants;
using AceleraDev.CrossCutting.Utils;
using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace AceleraDev.Data.Context
{
    public class AceleraDevContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AceleraDevContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

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


            modelBuilder.Entity<Usuario>().HasData(new Usuario { Nome = "Administrador", Email = "admin@mail.com", Senha = "1234".ToHashMD5(), Perfil = Constants.PERFIL_ADMIN });
            modelBuilder.Entity<Usuario>().HasData(new Usuario { Nome = "Vendedor", Email = "vendedor@mail.com", Senha = "1234".ToHashMD5(), Perfil = Constants.PERFIL_VENDEDOR });
        }

        internal string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
