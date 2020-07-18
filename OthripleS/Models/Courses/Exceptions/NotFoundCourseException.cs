using System;

namespace OtripleS.Web.Api.Models.Courses.Exceptions
{
    public class NotFoundCourseException : Exception
    {
        public NotFoundCourseException(Guid courseId)
            : base($"Couldn't find course with Id: {courseId}")
        {

        }
    }
}
