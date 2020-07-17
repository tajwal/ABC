using ABC.Models;
using Moq;
using System;
using Xunit;
using XYZv2;
using XYZv2.Models;

namespace ABCTests.Services
{
    public class XYZServiceTests
    {
        [Fact]
        public void ShouldCallXyzBrokerToSendNotification()
        {
            var xyzBrokerMock = new Mock<ABCNotification>();
            Guid notificationId = Guid.NewGuid();
            Guid notificationResponseId = Guid.NewGuid();

            var notification = new Notificationv2()
            {
                Id = notificationId
            };

            var notificationResponse = new NotificationResponsev2()
            {
                Id=notificationResponseId
            };

            var expectedNotificationReponse = new ABCNotificationResponse()
            {
                Id = notificationResponseId
            };

            //xyzBrokerMock.Setup()

        }
    }
}
