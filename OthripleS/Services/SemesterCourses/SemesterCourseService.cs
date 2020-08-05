using OtripleS.Web.Api.Brokers.DateTimes;
using OtripleS.Web.Api.Brokers.Loggings;
using OtripleS.Web.Api.Brokers.Storage;
using OtripleS.Web.Api.Models.SemesterCourses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OtripleS.Web.Api.Services.SemesterCourses
{
    public partial class SemesterCourseService : ISemesterCourseService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        public SemesterCourseService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker
            )
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<SemesterCourse> CreateSemesterCourseAsync(
            SemesterCourse semesterCourse) =>
        TryCatch(async () =>
        {
            ValidateSemesterCourseOnCreate(semesterCourse);

            return await this.storageBroker.InsertSemesterCourseAsync(semesterCourse);
        });

        public async ValueTask<SemesterCourse> DeleteSemesterCourseAsync(
            Guid semesterCourseId)
        {
            ValidateSemesterCourseId(semesterCourseId);

            SemesterCourse maybesemesterCourse =
                await this.storageBroker.SelectSemesterCourseByIdAsync(semesterCourseId);

            ValidateStorageSemesterCourse(maybesemesterCourse, semesterCourseId);

            return await this.storageBroker.DeleteSemesterCourseAsync(maybesemesterCourse);
        }

        public async ValueTask<SemesterCourse> ModifySemesterCourseAsync(
            SemesterCourse semesterCourse)
        {
            ValidateSemesterCourseOnModify(semesterCourse);

            SemesterCourse maybeSemesterCourse =
                await storageBroker.SelectSemesterCourseByIdAsync(semesterCourse.Id);
            ValidateStorageSemesterCourse(maybeSemesterCourse, semesterCourse.Id);
            ValidateAgainstStorageSemesterCourseOnModify(semesterCourse, maybeSemesterCourse);

            return await this.storageBroker.UpdateSemesterCourseAsync(semesterCourse);
        }

        public IQueryable<SemesterCourse> RetrieveAllSemesterCourses() =>
            TryCatch(() =>
            {
                IQueryable<SemesterCourse> storageSemesterCourses =
                this.storageBroker.SelectAllSemesterCourses();

                ValidateStorageSemesterCourses(storageSemesterCourses);

                return storageSemesterCourses;
            });

        public ValueTask<SemesterCourse> RetrieveSemesterCourseById(
            Guid semesterCourseId) =>
         TryCatch(async () =>
         {
             ValidateSemesterCourseId(semesterCourseId);

             SemesterCourse storageSemesterCourse =
              await this.storageBroker.SelectSemesterCourseByIdAsync(semesterCourseId);

             ValidateStorageSemesterCourse(storageSemesterCourse, semesterCourseId);

             return storageSemesterCourse;
         });
    }
}
