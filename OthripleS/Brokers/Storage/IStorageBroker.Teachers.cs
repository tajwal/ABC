using System;
using System.Linq;
using System.Threading.Tasks;
using OtripleS.Web.Api.Models.Teachers;

namespace OtripleS.Web.Api.Brokers.Storage
{
    public partial interface IStorageBroker
    {
        public ValueTask<Teacher> InsertTeacherAsync(Teacher teacher);
        public IQueryable<Teacher> SelectAllTeachers();
        public ValueTask<Teacher> SelectTeacherByIdAsync(Guid teacherId);
        public ValueTask<Teacher> UpdateTeacherAsync(Teacher teacher);
        public ValueTask<Teacher> DeleteTeacherAsync(Teacher teacher);
    }
}
