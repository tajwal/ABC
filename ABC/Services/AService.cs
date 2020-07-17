using ABC.Brokers;
using ABC.Models;
using System;
using XYZ.Models;
using XYZv2.Models;

namespace ABC.Services
{
    public class AService : IAService
    {
        private readonly IXYZService xYZService;
        public AService(IXYZService xYZService)
        {
            this.xYZService = xYZService;
        }
        public void DoStuffA(ABCNotification notification)
        {
            this.xYZService.SendNotification(notification);
        }
    }
}
