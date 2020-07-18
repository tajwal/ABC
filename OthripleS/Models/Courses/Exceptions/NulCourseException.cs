using System;

namespace OtripleS.Web.Api.Models.Courses.Exceptions
{
    public class NulCourseException : Exception
    {
        public NulCourseException() : base("The course is null.")
        {

        }
    }
}
