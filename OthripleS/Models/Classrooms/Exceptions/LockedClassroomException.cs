using System;

namespace OtripleS.Web.Api.Models.Classrooms.Exceptions
{
    public class LockedClassroomException : Exception
    {
        public LockedClassroomException(Exception innerException)
            : base("Locked classroom record exception, contact support", innerException)
        {

        }
    }
}
