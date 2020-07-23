using System;

namespace OtripleS.Web.Api.Models.Classrooms.Exceptions
{
    public class AlreadyExistsClassroomException : Exception
    {
        public AlreadyExistsClassroomException(Exception innerException)
            : base("Classroom with same id already exists,", innerException)
        {

        }
    }
}
