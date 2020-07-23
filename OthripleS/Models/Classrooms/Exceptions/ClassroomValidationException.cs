using System;

namespace OtripleS.Web.Api.Models.Classrooms.Exceptions
{
    public class ClassroomValidationException : Exception
    {
        public ClassroomValidationException(Exception innerException)
            : base("Invalid input, contact support.", innerException)
        {

        }
    }
}
