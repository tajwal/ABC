using System;

namespace OthripleS.Models.Courses.Exceptions
{
    public class LockedCourseException:Exception
    {
        public LockedCourseException(Exception innerException)
            :base("Locked course record exception, contact support",innerException)
        {

        }
    }
}
