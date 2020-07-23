using System;

namespace OtripleS.Web.Api.Models.Classrooms.Exceptions
{
    public class InvalidClassroomInputException : Exception
    {
        public InvalidClassroomInputException(string parameterName, object parameterValue)
            : base($"Invalid Classroom, " +
                  $"ParameterName: {parameterName}, " +
                  $"ParameterValue: {parameterValue}.")
        {

        }
    }
}
