using ABC.Brokers;
using ABC.Services;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;
using XYZ;
using XYZ.Models;

namespace ABCTests.Services
{
    public class BServicesTests
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
            var bservice = new BService(xyzBrokerMock.Object);
            bservice.DoStuffB(notification);

            //then
            xyzBrokerMock.Verify(b => b.SendNotification(notification), Times.Once);
        }
    }
}
