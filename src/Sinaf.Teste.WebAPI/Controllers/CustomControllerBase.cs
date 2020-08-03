using Microsoft.AspNetCore.Mvc;
using Sinaf.Teste.Domain.Notification;
using System.Linq;

namespace Sinaf.Teste.WebAPI.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        protected readonly NotificationContext NotificationContext;

        protected CustomControllerBase(NotificationContext notificationContext)
        {
            NotificationContext = notificationContext;           
        }

        protected new IActionResult Response(object result = null)
        {
            if (!NotificationContext.HasNotifications)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = NotificationContext.Notifications.Select(n => n.Message)
            });
        }
    }
}
