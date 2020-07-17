using ABC.Brokers;
using ABC.Models;
using System;
using XYZv2;
using XYZv2.Models;

namespace ABC.Services
{
    public class XYZService : IXYZService
    {
        private readonly IXYZBroker xYZBroker;
        public XYZService(IXYZBroker xYZBroker)
        {
            this.xYZBroker = xYZBroker;
        }
        public ABCNotificationResponse SendNotification(ABCNotification notificatoin)
        {
            var notificationv2 = MapTOXYZNotification(notificatoin);
            var notificationResponse = xYZBroker.SendNotification(notificationv2);

            return MapToABCNotificationResponse(notificationResponse);

        }

        private ABCNotificationResponse MapToABCNotificationResponse(
            NotificationResponsev2 notificationResponsev2)
        {
            return new ABCNotificationResponse()
            {
                Id = notificationResponsev2.Id
            };
        }

        private Notificationv2 MapTOXYZNotification(
            ABCNotification notificationResponse)
        {
            return new Notificationv2()
            {
                Id = notificationResponse.Id 
            };
        }
    }
}
