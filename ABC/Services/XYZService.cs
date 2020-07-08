using ABC.Brokers;
using ABC.Models;
using System;

namespace ABC.Services
{
    public class XYZService : IXYZService
    {
        private readonly IXYZBroker xYZBroker;
        public XYZService(IXYZBroker xYZBroker)
        {
            this.xYZBroker = xYZBroker;
        }
        public ACBNotification SendNotification(ACBNotification notificatoin)
        {
            throw new NotImplementedException();
        }
    }
}
