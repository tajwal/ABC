using ABC.Models;

namespace ABC.Services
{
    public interface IXYZService
    {
        ABCNotificationResponse SendNotification(ABCNotification notificatoin);
    }
}
