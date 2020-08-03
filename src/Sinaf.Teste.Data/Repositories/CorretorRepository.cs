using Sinaf.Teste.Data.Context;
using Sinaf.Teste.Domain.Entities;
using Sinaf.Teste.Domain.Interfaces.Repositories;

namespace Sinaf.Teste.Data.Repositories
{
    public class CorretorRepository : RepositoryBase<Corretor>, ICorretorRepository
    {
        public CorretorRepository(SinafContext context) : base(context)
        {
        }
    }
}
