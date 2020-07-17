using ABC.Brokers;
using ABC.Models;
using ABC.Services;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;
using XYZ;
using XYZ.Models;
using XYZv2;

namespace ABCTests.Services
{
    public class AServicesTests
    {
        [Fact]
        public void ShouldCallXyzBroker()
        {
            //given
            var xyzBrokerMock = new Mock<IXYZService>();
            ABCNotification notification = new Filler<ABCNotification>().Create();

            ABCNotificationResponse notificationResponse =
                new Filler<ABCNotificationResponse>().Create();

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
