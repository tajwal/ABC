using System;

namespace OtripleS.Web.Api.Models.Courses.Exceptions
{
    public class CourseServiceException : Exception
    {
        public CourseServiceException(Exception innerExceptoin)
            : base("Service error occurred, contact suppoer.", innerExceptoin)
        {

        }
    }
}
