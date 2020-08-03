using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Teste.Domain.Entities;

namespace Sinaf.Teste.Data.Mappings
{
    public class CoberturaMapping : IEntityTypeConfiguration<Cobertura>
    {
        public void Configure(EntityTypeBuilder<Cobertura> builder)
        {
            builder.ToTable("Cobertura");

            builder.HasKey(b => b.Id);

            builder.Property(p => p.Nome)
                   .HasColumnType("varchar(256)")
                   .IsRequired(true);

            builder.Property(p => p.ImportanciaSegurada)
                   .HasColumnType("decimal(16,2)")
                   .IsRequired(true);
        }
    }
}
