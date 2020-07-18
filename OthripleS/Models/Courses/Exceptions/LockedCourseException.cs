using System;

namespace OtripleS.Web.Api.Models.Courses.Exceptions
{
    public class LockedCourseException : Exception
    {
        public LockedCourseException(Exception innerException)
            : base("Locked course record exception, contact support", innerException)
        {

        }
    }
}
