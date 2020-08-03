using Sinaf.Teste.Domain.Entities;
using Sinaf.Teste.Domain.Interfaces.Repositories;
using Sinaf.Teste.Domain.Interfaces.Services;
using Sinaf.Teste.Domain.Notification;

namespace Sinaf.Teste.Domain.Services
{
    public class ApoliceService : ServiceBase<Apolice>, IApoliceService
    {
        public ApoliceService(IUnitOfWork unitOfWork, IApoliceRepository repository, NotificationContext notificationContext) : base(unitOfWork, repository, notificationContext)
        {
        }

        public override void Insert(Apolice apolice)
        {
            ValidarNovaApolice(apolice);

            apolice.CalcularPremio();

            base.Insert(apolice);

            if (!NotificationContext.HasNotifications)
                UnitOfWork.Commit();         
        }

        private void ValidarNovaApolice(Apolice apolice)
        {
            apolice.ValidarInclusao();
            foreach (var item in apolice.Notifications.Notifications)
                this.NotificationContext.AddNotification(item.Message);

            apolice.Corretor.ValidarInclusao();
            foreach (var item in apolice.Corretor.Notifications.Notifications)
                this.NotificationContext.AddNotification(item.Message);

            foreach (var cobertura in apolice.Coberturas)
            {
                cobertura.ValidarInclusao();
                foreach (var item in cobertura.Notifications.Notifications)
                    this.NotificationContext.AddNotification(item.Message);
            }                                            
        }
    }
}
