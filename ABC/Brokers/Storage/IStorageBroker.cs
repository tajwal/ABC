using ABC.Models;
using System.Threading.Tasks;

namespace ABC.Brokers.Storage
{
    public interface IStorageBroker
    {
        Task AddStudentAsync(Student student);
    }
}
