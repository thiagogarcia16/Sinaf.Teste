using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Teste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sinaf.Teste.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(b => b.Id);

            builder.Property(p => p.Descricao)
                   .HasColumnType("varchar(512)")
                   .IsRequired(true);
        }
    }
}
