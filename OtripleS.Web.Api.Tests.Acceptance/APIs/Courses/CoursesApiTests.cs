﻿using System;
using System.Threading.Tasks;
using FluentAssertions;
using OtripleS.Web.Api.Models.Courses;
using OtripleS.Web.Api.Tests.Acceptance.Brokers;
using Tynamix.ObjectFiller;
using Xunit;

namespace OtripleS.Web.Api.Tests.Acceptance.APIs.Courses
{
    [Collection(nameof(ApiTestCollection))]
    public partial class CoursesApiTests
    {
        private readonly OtripleSApiBroker courseBroker;

        public CoursesApiTests(OtripleSApiBroker courseBroker)
        {
            this.courseBroker = courseBroker;
        }

        private Course CreateRandumCourse() =>
            CreateRandumCourseFiller().Create();

        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private Filler<Course> CreateRandumCourseFiller()
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            Guid posterId = Guid.NewGuid();

            var filler = new Filler<Course>();

            filler.Setup()
                .OnProperty(course => course.CreatedBy).Use(posterId)
                .OnProperty(course => course.UpdatedBy).Use(posterId)
                .OnProperty(course => course.CreatedDate).Use(now)
                .OnProperty(course => course.UpdatedDate).Use(now)
                .OnType<DateTimeOffset>().Use(GetRandomDateTime());

            return filler;
        }
    }
}
