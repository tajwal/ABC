using ABC.Models;
using Moq;
using Xunit;

namespace ABCTests.Services
{
    public class XYZServiceTests
    {
        [Fact]
        public void ShouldCallXyzBrokerToSendNotification()
        {
            var xyzBrokerMock = new Mock<ACBNotification>();
        }
    }
}
