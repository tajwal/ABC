using System;

namespace OtripleS.Web.Api.Models.Courses.Exceptions
{
    public class InvalidCourseInputException : Exception
    {
        public InvalidCourseInputException(string parameterName, object parameterValue)
            : base($"Invalid Course, " +
                  $"ParameterName: {parameterName}, " +
                  $"ParameterValue: {parameterValue}.")
        {

        }
    }
}
