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
    public class BServicesTests
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
            var bservice = new BService(xyzBrokerMock.Object);
            bservice.DoStuffB(notification);

            //then
            xyzBrokerMock.Verify(b => b.SendNotification(notification), Times.Once);
        }
    }
}
