using System;

namespace OthripleS.Models.Courses.Exceptions
{
    public class CourseServiceException:Exception
    {
        public CourseServiceException(Exception innerExceptoin)
            : base("Service error occurred, contact suppoer.", innerExceptoin)
        {

        }
    }
}
