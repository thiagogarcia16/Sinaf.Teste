using Sinaf.Teste.Data.Context;
using Sinaf.Teste.Data.Repositories;
using Sinaf.Teste.Domain.Interfaces.Repositories;

namespace Sinaf.Teste.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SinafContext _dbContext;

        private IApoliceRepository apoliceRepository;
        private ICorretorRepository corretorRepository;
        public UnitOfWork(SinafContext dbContext) => _dbContext = dbContext;

        public IApoliceRepository Apolices
        {
            get { return apoliceRepository = apoliceRepository ?? new ApoliceRepository(_dbContext); }
        }

        public ICorretorRepository Corretores
        {
            get { return corretorRepository = corretorRepository ?? new CorretorRepository(_dbContext); }
        }

        public int Commit() => _dbContext.SaveChanges();      
        public void Rollback() => _dbContext.Dispose();
       
    }
}
