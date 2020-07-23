using System;

namespace OtripleS.Web.Api.Models.Classrooms.Exceptions
{
    public class NotFoundClassroomException : Exception
    {
        public NotFoundClassroomException(Guid classroomId)
            : base($"Couldn't find classroom with Id: {classroomId}")
        {

        }
    }
}
