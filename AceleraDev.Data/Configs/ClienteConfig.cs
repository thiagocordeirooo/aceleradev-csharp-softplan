using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceleraDev.Data.Configs
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Cpf).HasMaxLength(11).HasColumnType("varchar(11)");
        }
    }
}
