using System;

namespace OtripleS.Web.Api.Models.Courses.Exceptions
{
    public class AlreadyExistsCourseException : Exception
    {
        public AlreadyExistsCourseException(Exception innerException)
            : base("Course with same id already exists,", innerException)
        {

        }
    }
}
