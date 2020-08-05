// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace OtripleS.Web.Api.Models.SemesterCourses.Exceptions
{
    public class SemesterCourseServiceException : Exception
    {
        public SemesterCourseServiceException(Exception innerExceptoin)
            : base("Service error occurred, contact suppoer.", innerExceptoin)
        {

        }
    }
}
