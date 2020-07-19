using System;
using System.Linq;
using System.Threading.Tasks;
using OtripleS.Web.Api.Brokers.DateTimes;
using OtripleS.Web.Api.Brokers.Loggings;
using OtripleS.Web.Api.Brokers.Storage;
using OtripleS.Web.Api.Models.Courses;

namespace OtripleS.Web.Api.Services.Courses
{
    public partial class CourseService : ICourseService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        public CourseService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker
            )
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Course> CreateCourseAsync(Course course)
        {
            return this.storageBroker.InsertCourseAsync(course);

        }
        //TryCatch(async () =>
        //{
        //    ValidateCourseOnCreate(course);

        //    return await this.storageBroker.InsertCourseAsync(course);
        //});


        public async ValueTask<Course> DeleteCourseAsync(Guid courseId)
        {
            ValidateCourseId(courseId);

            Course maybeCourse =
               await this.storageBroker.SelectCourseByIdAsync(courseId);

            ValidateStorageCourse(maybeCourse, courseId);

            return await this.storageBroker.DeleteCourseAsync(maybeCourse);
        }

        public async ValueTask<Course> ModifyCourseAsync(Course course)
        {
            ValidateCourseOnModify(course);
            Course MyCourse = await storageBroker.SelectCourseByIdAsync(course.Id);
            ValidateStorageCourse(MyCourse, course.Id);
            ValidateAgainstStorageCourseOnModify(course, MyCourse);

            return await this.storageBroker.UpdateCourseAsync(course);
        }

        public IQueryable<Course> RetrieveAllCourses()
        {
            IQueryable<Course> storageCourses = this.storageBroker.SelectAllCourses();
            ValidateStorageCourses(storageCourses);

            return storageCourses;
        }
        //TryCatch(() =>
        //{
        //    IQueryable<Course> storageCourses = this.storageBroker.SelectAllCourses();
        //    ValidateStorageCourses(storageCourses);

        //    return storageCourses;
        //});

        public async ValueTask<Course> RetrieveCourseById(Guid courseId)
        {
            Course storageCourse = await this.storageBroker.SelectCourseByIdAsync(courseId);
            ValidateStorageCourse(storageCourse, courseId);

            return storageCourse;
        }
        //TryCatch(async () =>
        //{
        //    Course storageCourse = await this.storageBroker.SelectCourseByIdAsync(courseId);
        //    ValidateStorageCourse(storageCourse, courseId);

        //    return storageCourse;
        //});
    }
}
