using ABC.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ABC.Brokers.Storage
{
    public class StorageBroker : DbContext, IStorageBroker
    {
        private DbSet<Student> Students { get; set; }

        public async Task AddStudentAsync(Student student)
        {
            await this.Students.AddAsync(student);
            await this.SaveChangesAsync();
        }
    }
}
