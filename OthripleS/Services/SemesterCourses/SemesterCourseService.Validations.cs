using OtripleS.Web.Api.Models.SemesterCourses;
using OtripleS.Web.Api.Models.SemesterCourses.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtripleS.Web.Api.Services.SemesterCourses
{
    public partial class SemesterCourseService
    {
        private void ValidateSemesterCourseOnCreate(SemesterCourse semesterCourse)
        {
            ValidateSemesterCourse(semesterCourse);
            ValidateSemesterCourseId(semesterCourse.Id);
            ValidateSemesterCourseIds(semesterCourse);
            ValidateSemesterCourseStrings(semesterCourse);
            ValidateSemesterCourseDates(semesterCourse);
            ValidateCreatedSignature(semesterCourse);
            ValidateCreatedDateIsRecent(semesterCourse);
        }

        private void ValidateSemesterCourseOnModify(SemesterCourse semesterCourse)
        {
            ValidateSemesterCourse(semesterCourse);
            ValidateSemesterCourseId(semesterCourse.Id);
            ValidateSemesterCourseStrings(semesterCourse);
            ValidateSemesterCourseIds(semesterCourse);
            ValidateSemesterCourseDates(semesterCourse);
            ValidateDatesAreNotSame(semesterCourse);
            ValidateUpdatedDateIsRecent(semesterCourse);
        }

        private void ValidateSemesterCourse(SemesterCourse semesterCourse)
        {
            if (semesterCourse is null)
            {
                throw new NullSemesterCourseException();
            }
        }

        private void ValidateSemesterCourseId(Guid semesterCourseId)
        {
            if (semesterCourseId == Guid.Empty)
            {
                throw new InvalidSemesterCourseInputException(
                    parameterName: nameof(SemesterCourse.Id),
                    parameterValue: semesterCourseId);
            }
        }

        private void ValidateSemesterCourseIds(SemesterCourse semesterCourse)
        {
            switch (semesterCourse)
            {
                case { } when IsInvalid(semesterCourse.CreatedBy):
                    throw new InvalidSemesterCourseInputException(
                        parameterName: nameof(SemesterCourse.CreatedBy),
                        parameterValue: semesterCourse.CreatedBy);

                case { } when IsInvalid(semesterCourse.UpdatedBy):
                    throw new InvalidSemesterCourseInputException(
                        parameterName: nameof(SemesterCourse.UpdatedBy),
                        parameterValue: semesterCourse.UpdatedBy);
            }
        }

        private void ValidateSemesterCourseStrings(SemesterCourse semesterCourse)
        {
            switch (semesterCourse)
            {
                case { } when IsInvalid(semesterCourse.ClassroomId):
                    throw new InvalidSemesterCourseInputException(
                        parameterName: nameof(SemesterCourse.ClassroomId),
                        parameterValue: semesterCourse.Classroom);

                case { } when IsInvalid(semesterCourse.CourseId):
                    throw new InvalidSemesterCourseInputException(
                        parameterName: nameof(SemesterCourse.CourseId),
                        parameterValue: semesterCourse.CourseId);
                case { } when IsInvalid(semesterCourse.TeacherId):
                    throw new InvalidSemesterCourseInputException(
                        parameterName: nameof(SemesterCourse.TeacherId),
                        parameterValue: semesterCourse.TeacherId);
            }
        }

        private void ValidateSemesterCourseDates(SemesterCourse semesterCourse)
        {
            //switch (semesterCourse)
            //{
            //    case { } when semesterCourse.CreatedDate == default:
            //        throw new InvalidSemesterCourseInputException(
            //            parameterName: nameof(case { } when IsInvalid(semesterCourse.Id):
            //        throw new InvalidSemesterCourseInputException(
            //            parameterName: nameof(SemesterCourse.CourseId),
            //            parameterValue: semesterCourse.CourseId);.CreatedDate),
            //            parameterValue: semesterCourse.CreatedDate);

            //    case { } when semesterCourse.UpdatedDate == default:
            //        throw new InvalidSemesterCourseInputException(
            //            parameterName: nameof(Course.UpdatedDate),
            //            parameterValue: semesterCourse.UpdatedDate);
            //}
        }

        private void ValidateCreatedSignature(SemesterCourse semesterCourse)
        {
            if (semesterCourse.CreatedBy != semesterCourse.UpdatedBy)
            {
                throw new InvalidSemesterCourseInputException(
                    parameterName: nameof(SemesterCourse.UpdatedBy),
                    parameterValue: semesterCourse.UpdatedBy);
            }
            else if (semesterCourse.CreatedDate != semesterCourse.UpdatedDate)
            {
                throw new InvalidSemesterCourseInputException(
                    parameterName: nameof(SemesterCourse.UpdatedDate),
                    parameterValue: semesterCourse.UpdatedDate);
            }
        }

        private void ValidateCreatedDateIsRecent(SemesterCourse semsterCourse)
        {
            if (IsDateNotRecent(semsterCourse.CreatedDate))
            {
                throw new InvalidSemesterCourseInputException(
                    parameterName: nameof(semsterCourse.CreatedDate),
                    parameterValue: semsterCourse.CreatedDate);
            }
        }

        private void ValidateDatesAreNotSame(SemesterCourse semesterCourse)
        {
            if (semesterCourse.CreatedDate == semesterCourse.UpdatedDate)
            {
                throw new InvalidSemesterCourseInputException(
                    parameterName: nameof(SemesterCourse.UpdatedDate),
                    parameterValue: semesterCourse.UpdatedDate);
            }
        }

        private void ValidateUpdatedDateIsRecent(SemesterCourse semsterCourse)
        {
            if (IsDateNotRecent(semsterCourse.UpdatedDate))
            {
                throw new InvalidSemesterCourseInputException(
                    parameterName: nameof(semsterCourse.UpdatedDate),
                    parameterValue: semsterCourse.UpdatedDate);
            }
        }

        private void ValidateStorageSemesterCourse(SemesterCourse storageSemesterCourse, Guid semesterCourseId)
        {
            if (storageSemesterCourse == null)
            {
                throw new NotFoundSemesterCourseException(semesterCourseId);
            }
        }

        private bool IsDateNotRecent(DateTimeOffset dateTime)
        {
            DateTimeOffset now = this.dateTimeBroker.GetCurrentDateTime();
            int oneMinute = 1;
            TimeSpan difference = now.Subtract(dateTime);

            return Math.Abs(difference.TotalMinutes) > oneMinute;
        }

        private void ValidateStorageSemesterCourses(IQueryable<SemesterCourse> storageSemesterCourses)
        {
            if (storageSemesterCourses.Count() == 0)
            {
                this.loggingBroker.LogWarning("No courses for semester found in storage.");
            }
        }

        private void ValidateAgainstStorageSemesterCourseOnModify(SemesterCourse inputSemesterCourse, 
            SemesterCourse storageSemesterCourse)
        {
            switch (inputSemesterCourse)
            {
                case { } when inputSemesterCourse.CreatedDate != storageSemesterCourse.CreatedDate:
                    throw new InvalidSemesterCourseInputException(
                        parameterName: nameof(SemesterCourse.CreatedDate),
                        parameterValue: inputSemesterCourse.CreatedDate);

                case { } when inputSemesterCourse.CreatedBy != storageSemesterCourse.CreatedBy:
                    throw new InvalidSemesterCourseInputException(
                        parameterName: nameof(SemesterCourse.CreatedBy),
                        parameterValue: inputSemesterCourse.CreatedBy);

                case { } when inputSemesterCourse.UpdatedDate == storageSemesterCourse.UpdatedDate:
                    throw new InvalidSemesterCourseInputException(
                        parameterName: nameof(SemesterCourse.UpdatedDate),
                        parameterValue: inputSemesterCourse.UpdatedDate);
            }
        }

        private static bool IsInvalid(string input) => String.IsNullOrWhiteSpace(input);

        private static bool IsInvalid(Guid input) => input == default;
    }
}
