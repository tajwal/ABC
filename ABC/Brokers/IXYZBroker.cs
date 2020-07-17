using ABC.Models;
using XYZv2;
using XYZv2.Models;

namespace ABC.Brokers
{
    public interface IXYZBroker
    {
        NotificationResponsev2 SendNotification(Notificationv2 notification);
    }
}
