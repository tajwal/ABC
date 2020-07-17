using ABC.Models;
using System.Threading.Tasks;

namespace ABC.Services
{
    public interface IStudentService
    {
        Task RegisterStudentAsync(Student student);
    }
}
