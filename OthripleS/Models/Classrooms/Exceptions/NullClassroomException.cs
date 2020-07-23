using System;

namespace OtripleS.Web.Api.Models.Classrooms.Exceptions
{
    public class NullClassroomException : Exception
    {
        public NullClassroomException() : base("The course is null.")
        {

        }
    }
}
