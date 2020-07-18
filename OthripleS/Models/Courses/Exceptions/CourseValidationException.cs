using System;

namespace OthripleS.Models.Courses.Exceptions
{
    public class CourseValidationException:Exception
    {
        public CourseValidationException(Exception innerException)
            :base("Invalid input, contact support.",innerException)
        {

        }
    }
}
