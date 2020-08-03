namespace Sinaf.Teste.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IApoliceRepository Apolices { get; }
        ICorretorRepository Corretores { get; }

        int Commit();
        void Rollback();
    }
}
