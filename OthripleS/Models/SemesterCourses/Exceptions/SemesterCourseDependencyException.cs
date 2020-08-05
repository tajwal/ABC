﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace OtripleS.Web.Api.Models.SemesterCourses.Exceptions
{
    public class SemesterCourseDependencyException : Exception
    {
        public SemesterCourseDependencyException(Exception innerException)
        : base("Service dependency error occurred, contact supper.", innerException)
        {

        }
    }
}