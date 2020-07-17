using ABC.Brokers;
using ABC.Models;
using System;
using XYZ.Models;
using XYZv2.Models;

namespace ABC.Services
{
    public class BService : IBService
    {
        private readonly IXYZService xYZService;
        public BService(IXYZService xYZService)
        {
            this.xYZService = xYZService;
        }
        public void DoStuffB(ABCNotification notification)
        {
            this.xYZService.SendNotification(notification);
        }
    }
}
