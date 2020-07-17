using ABC.Brokers.Storage;
using ABC.Models;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStorageBroker storageBroker;
        public StudentService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        public async Task RegisterStudentAsync(Student student)
        {
          await   storageBroker.AddStudentAsync(student);
        }
    }
}
