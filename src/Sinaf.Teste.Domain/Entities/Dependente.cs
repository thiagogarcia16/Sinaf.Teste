namespace Sinaf.Teste.Domain.Entities
{
    public class Dependente : EntityBase
    {
        public string Nome { get; private set; }
        public long ApoliceId { get; private set; }
        public Apolice Apolice { get; private set; }

        public Dependente(string nome) => this.Nome = nome;
    }
}
