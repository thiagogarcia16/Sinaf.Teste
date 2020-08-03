using Microsoft.EntityFrameworkCore;
using Sinaf.Teste.Data.Context;
using Sinaf.Teste.Domain.Entities;
using Sinaf.Teste.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Sinaf.Teste.Data.Repositories
{
    public class ApoliceRepository : RepositoryBase<Apolice>, IApoliceRepository
    {
        public ApoliceRepository(SinafContext context) : base(context)
        {
        }

        public Apolice Get(long clienteId)
        {
            return DbSet.Include(a => a.Cliente)
                            .ThenInclude(c => c.Enderecos)
                        .Include(a => a.Cliente)
                            .ThenInclude(c => c.Telefones)
                        .Include(a => a.Coberturas)
                        .Include(a => a.Corretor)
                        .Include(a => a.Dependentes)
                        .SingleOrDefault(a => a.ClienteId == clienteId);
        }

        public override IEnumerable<Apolice> GetAll()
        {
            return DbSet.Include(a => a.Cliente)
                            .ThenInclude(c => c.Enderecos)
                        .Include(a => a.Cliente)
                            .ThenInclude(c => c.Telefones)
                        .Include(a => a.Coberturas)
                        .Include(a => a.Corretor)
                        .Include(a => a.Dependentes)
                        .ToList();
        }
    }
}
