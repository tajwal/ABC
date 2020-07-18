using System;

namespace OthripleS.Models.Courses.Exceptions
{
    public class CourseDependencyException:Exception
    {
        public CourseDependencyException(Exception innerException)
        :base("Service dependency error occurred, contact supper.",innerException)
        {

        }
    }
}
