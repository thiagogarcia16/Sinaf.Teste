using Sinaf.Teste.Domain.Entities;

namespace Sinaf.Teste.Domain.Interfaces.Repositories
{
    public interface IApoliceRepository : IRepositoryBase<Apolice>
    {
        Apolice Get(long clienteId);
    }
}
