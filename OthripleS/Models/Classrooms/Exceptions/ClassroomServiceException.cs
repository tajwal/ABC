using System;

namespace OtripleS.Web.Api.Models.Classrooms.Exceptions
{
    public class ClassroomServiceException : Exception
    {
        public ClassroomServiceException(Exception innerExceptoin)
            : base("Service error occurred, contact suppoer.", innerExceptoin)
        {

        }
    }
}
