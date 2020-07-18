using System.Threading.Tasks;
using FluentAssertions;
using OtripleS.Web.Api.Models.Courses;
using Xunit;

namespace OtripleS.Web.Api.Tests.Acceptance.APIs.Courses
{
    public partial class CoursesApiTests
    {
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
