using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Teste.Domain.Entities;

namespace Sinaf.Teste.Data.Mappings
{
    public class ApoliceMapping : IEntityTypeConfiguration<Apolice>
    {
        public void Configure(EntityTypeBuilder<Apolice> builder)
        {
            builder.ToTable("Apolice");

            builder.HasKey(b => b.Id);

            builder.Property(p => p.Premio)
                   .HasColumnType("decimal(16,2)")
                   .IsRequired(true);       
        }
    }
}
