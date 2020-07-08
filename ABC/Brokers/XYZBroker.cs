using XYZ;
using XYZ.Models;

namespace ABC.Brokers
{
    public class XYZBroker:IXYZBroker
    {
        private readonly NotificationService notificationService;
        public XYZBroker()
        {
            this.notificationService = new NotificationService();
        }
        NotificationResponse IXYZBroker.SendNotification(Notification notification)
        {
            return this.notificationService.SendNotification(notification);
        }
    }
}