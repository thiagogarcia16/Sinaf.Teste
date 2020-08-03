using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Teste.Domain.Entities;

namespace Sinaf.Teste.Data.Mappings
{
    public class DependenteMapping : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.ToTable("Dependente");

            builder.HasKey(b => b.Id);

            builder.Property(p => p.Nome)
                   .HasColumnType("varchar(256)")
                   .IsRequired(true);
        }
    }
}
