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
            new Filler<Course>().Create();

        [Fact]
        public async Task ShouldPostCourseAsync()
        {
            // given
            Course randomCourse = CreateRandumCourse();
            Course inputCourse = randomCourse;
            Course expectedCourse = inputCourse;

            // when 
            await this.courseBroker.PostCourseAsync(inputCourse);

            Course actualStudent =
                await this.courseBroker.GetCourseByIdAsync(inputCourse.Id);

            // then
            actualStudent.Should().BeEquivalentTo(expectedCourse);

            await this.courseBroker.DeleteStudentByIdAsync(actualStudent.Id);
        }

    }
}
