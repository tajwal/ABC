using ABC.Brokers;
using ABC.Services;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;
using XYZ;
using XYZ.Models;

namespace ABCTests.Services
{
    public class AServicesTests
    {
        [Fact]
        public void ShouldCallXyzBroker()
        {
            //given
            var xyzBrokerMock = new Mock<IXYZBroker>();
            Notification notification = new Filler<Notification>().Create();

            NotificationResponse notificationResponse =
                new Filler<NotificationResponse>().Create();

            xyzBrokerMock.Setup(x => x.SendNotification(notification))
                .Returns(notificationResponse);

            //when
            var aservice = new AService(xyzBrokerMock.Object);
            aservice.DoStuffA(notification);

            //then
            xyzBrokerMock.Verify(b => b.SendNotification(notification), Times.Once);
        }
    }
}
