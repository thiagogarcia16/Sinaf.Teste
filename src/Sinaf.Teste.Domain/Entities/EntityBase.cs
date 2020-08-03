using Sinaf.Teste.Domain.Notification;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sinaf.Teste.Domain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; set; }
        [NotMapped]
        public NotificationContext Notifications { get; set; }
    }
}
