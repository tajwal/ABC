using ABC.Brokers;
using System;
using XYZ.Models;

namespace ABC.Services
{
    public class AService : IAService
    {
        private readonly IXYZBroker xYZBroker;
        public AService(IXYZBroker xYZBroker)
        {
            this.xYZBroker = xYZBroker;
        }
        public void DoStuffA(Notification notification)
        {
            this.xYZBroker.SendNotification(notification);
        }
    }
}
