using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceleraDev.Data.Configs
{
    public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("endereco");
            
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Cliente).WithMany(p => p.Enderecos).HasForeignKey(p => p.ClienteId);
        }
    }
}
