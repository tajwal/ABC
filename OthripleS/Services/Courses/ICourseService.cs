using System;
using System.Linq;
using System.Threading.Tasks;
using OthripleS.Models.Courses;

namespace OtripleS.Web.Api.Services.Courses
{
    public interface ICourseService
    {
        IQueryable<Course> RetrieveAllCourses();
        ValueTask<Course> RetrieveCourseById(Guid courseId);
        ValueTask<Course> ModifyCourseAsync(Course course);
        ValueTask<Course> DeleteCourseAsync(Guid CourseId);
    }
}
