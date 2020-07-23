using System;

namespace OtripleS.Web.Api.Models.Courses.Exceptions
{
    public class NullCourseException : Exception
    {
        public NullCourseException() : base("The classroom is null.")
        {

        }
    }
}
