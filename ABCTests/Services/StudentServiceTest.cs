
using ABC.Brokers.Storage;
using ABC.Models;
using ABC.Services;
using Moq;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using Xunit;

namespace ABCTests.Services
{
    public class StudentServiceTest
    {
        [Fact]
        public async Task ShoudPersistWhenIsPassedIn()
        {
            //Given
            var StorageBrokerMoq = new Mock<IStorageBroker>();
            Student student = new Filler<Student>().Create();
            StorageBrokerMoq.Setup(b => b.AddStudentAsync(student));

            //when
            var studentService = new StudentService(StorageBrokerMoq.Object);
            await studentService.RegisterStudentAsync(student);

            //then
            StorageBrokerMoq.Verify(xx => xx.AddStudentAsync(student),Times.Once);
        }
    }
}
