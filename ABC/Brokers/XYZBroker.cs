using ABC.Models;
using XYZ;
using XYZ.Models;
using XYZv2;
using XYZv2.Models;

namespace ABC.Brokers
{
    public class XYZBroker:IXYZBroker
    {
        private readonly NotificationService notificationService;
        public XYZBroker()
        {
            this.notificationService = new NotificationService();
        }
        NotificationResponsev2 IXYZBroker.SendNotification(Notificationv2 notification)
        {
            return this.notificationService.SendNotification(notification);
        }
    }
}