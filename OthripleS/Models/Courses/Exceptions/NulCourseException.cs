using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OthripleS.Models.Courses.Exceptions
{
    public class NulCourseException:Exception
    {
        public NulCourseException():base("The course is null.")
        {

        }
    }
}
