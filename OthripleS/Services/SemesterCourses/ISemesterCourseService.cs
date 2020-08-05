using OtripleS.Web.Api.Models.SemesterCourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtripleS.Web.Api.Services.SemesterCourses
{
    public interface ISemesterCourseService
    {
        IQueryable<SemesterCourse> RetrieveAllSemesterCourses();
        ValueTask<SemesterCourse> RetrieveSemesterCourseById(Guid semesterCourseId);
        ValueTask<SemesterCourse> ModifySemesterCourseAsync(SemesterCourse semesterCourse);
        ValueTask<SemesterCourse> CreateSemesterCourseAsync(SemesterCourse semesterCourse);
        ValueTask<SemesterCourse> DeleteSemesterCourseAsync(Guid semesterCourseId);
    }
}
