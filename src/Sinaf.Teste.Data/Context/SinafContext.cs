using Microsoft.EntityFrameworkCore;
using Sinaf.Teste.Data.Mappings;
using Sinaf.Teste.Domain.Entities;

namespace Sinaf.Teste.Data.Context
{
    public class SinafContext : DbContext
    {
        public SinafContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Apolice> Apolices { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cobertura> Coberturas { get; set; }
        public virtual DbSet<Corretor> Corretores { get; set; }
        public virtual DbSet<Dependente> Dependentes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfiguration(new ApoliceMapping());
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new CoberturaMapping());
            modelBuilder.ApplyConfiguration(new CorretorMapping());
            modelBuilder.ApplyConfiguration(new DependenteMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new TelefoneMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
