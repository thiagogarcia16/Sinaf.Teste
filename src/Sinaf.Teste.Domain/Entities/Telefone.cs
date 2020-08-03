namespace Sinaf.Teste.Domain.Entities
{
    public class Telefone : EntityBase
    {
        public string Numero { get; private set; }

        public Telefone(string numero) => this.Numero = numero;
    }
}
