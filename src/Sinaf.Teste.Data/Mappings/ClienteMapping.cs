using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Teste.Domain.Entities;

namespace Sinaf.Teste.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(b => b.Id);

            builder.Property(p => p.Nome)          
                   .HasColumnType("varchar(256)")            
                   .IsRequired(true);

            builder.Property(p => p.Cpf)
                   .HasColumnType("varchar(11)")
                   .IsRequired(true);

            builder.Property(p => p.Email)
                   .HasColumnType("varchar(256)")
                   .IsRequired(true);

            builder.Property(p => p.DataNascimento)
                   .HasColumnType("date")
                   .IsRequired(true);

            builder.Property(p => p.Sexo)
                   .HasColumnType("char(1)")
                   .IsRequired(true);

        }
    }
}
