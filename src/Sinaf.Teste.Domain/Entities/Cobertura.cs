using Sinaf.Teste.Domain.Notification;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sinaf.Teste.Domain.Entities
{
    public class Cobertura : EntityBase
    {
        public string Nome { get; private set; }
        public decimal ImportanciaSegurada { get; private set; }
        public long ApoliceId { get; private set; }
        public Apolice Apolice { get; private set; }

        public Cobertura()
        {
            this.Notifications = new NotificationContext();
        }

        [NotMapped]
        private const decimal Percentual = 0.1m;
        [NotMapped]
        public static string CoberturaObrigatoria { get { return "assistência funeral"; } }

        public decimal CalcularPremio() => this.ImportanciaSegurada * Percentual;

        public void ValidarInclusao()
        {
            if (string.IsNullOrWhiteSpace(this.Nome))
                this.Notifications.AddNotification("Informe o nome da cobertura");

            if (this.ImportanciaSegurada <= 0)
                this.Notifications.AddNotification("Informe o valor da IS");            
        }

    }
}
