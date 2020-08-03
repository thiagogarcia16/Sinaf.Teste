using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Teste.Domain.Entities;

namespace Sinaf.Teste.Data.Mappings
{
    public class CorretorMapping : IEntityTypeConfiguration<Corretor>
    {
        public void Configure(EntityTypeBuilder<Corretor> builder)
        {
            builder.ToTable("Corretor");

            builder.HasKey(b => b.Id);

            builder.Property(p => p.Nome)
                 .HasColumnType("varchar(256)")
                 .IsRequired(true);
        }
    }
}
