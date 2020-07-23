using System;

namespace OtripleS.Web.Api.Models.Classrooms.Exceptions
{
    public class ClassroomDependencyException : Exception
    {
        public ClassroomDependencyException(Exception innerException)
        : base("Service dependency error occurred, contact supper.", innerException)
        {

        }
    }
}
