﻿using System;
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

        public ValueTask<Course> CreateCourseAsync(Course course) =>
        TryCatch(async () =>
        {
            ValidateCourseOnCreate(teacher);

            return await this.storageBroker.InsertCourseAsync(teacher);
        });


        public ValueTask<Course> DeleteCourseAsync(Guid CourseId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public ValueTask<Course> RetrieveCourseById(Guid courseId)
        {
            throw new NotImplementedException();
        }
    }
}
