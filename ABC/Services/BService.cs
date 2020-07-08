using ABC.Brokers;
using System;
using XYZ.Models;

namespace ABC.Services
{
    public class BService : IBService
    {
        private readonly IXYZBroker xYZBroker;
        public BService(IXYZBroker xYZBroker)
        {
            this.xYZBroker = xYZBroker;
        }
        public void DoStuffB(Notification notification)
        {
            this.xYZBroker.SendNotification(notification);
        }
    }
}
