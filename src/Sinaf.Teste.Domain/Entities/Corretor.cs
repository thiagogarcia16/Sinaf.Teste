using Sinaf.Teste.Domain.Notification;

namespace Sinaf.Teste.Domain.Entities
{
    public class Corretor : EntityBase
    {
        public string Nome { get; private set; }

        public Corretor()
        {
            this.Notifications = new NotificationContext();
        }

        public void ValidarInclusao()
        {
            if (string.IsNullOrWhiteSpace(this.Nome))
                this.Notifications.AddNotification("Informe o nome do corretor");      
        }
    }
}
