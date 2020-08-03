using System.Security.Cryptography;

namespace Sinaf.Teste.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public string Descricao { get; private set; }

        public Endereco(string descricao) => this.Descricao = descricao;

    }
}
