using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceleraDev.Data.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).IsRequired();

            builder.Property(p => p.Email).IsRequired();

            builder.Property(p => p.Senha).IsRequired();

            builder.Property(p => p.Perfil).IsRequired();
        }
    }
}
