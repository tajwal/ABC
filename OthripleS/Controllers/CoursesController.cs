using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OtripleS.Web.Api.Models.Courses;
using OtripleS.Web.Api.Models.Courses.Exceptions;
using OtripleS.Web.Api.Services.Courses;
using RESTFulSense.Controllers;


namespace OtripleS.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : RESTFulController
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService) =>
            this.courseService = courseService;

        [HttpPost]
        public async ValueTask<ActionResult<Course>> PostCourseAsync(
            [FromBody] Course course)
        {
            try
            {
                Course persistedCourse =
                    await this.courseService.CreateCourseAsync(course);

                return Ok(persistedCourse);
            }
            catch (CourseValidationException courseValidationException)
                when (courseValidationException.InnerException is AlreadyExistsCourseException)
            {
                string innerMessage = GetInnerMessage(courseValidationException);

                return Conflict(innerMessage);
            }
            catch (CourseValidationException courseValidationException)
            {
                string innerMessage = GetInnerMessage(courseValidationException);

                return BadRequest(innerMessage);
            }
            catch (CourseDependencyException courseDependencyException)
            {
                return Problem(courseDependencyException.Message);
            }
            catch (CourseServiceException couServiceException)
            {
                return Problem(couServiceException.Message);
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<Course>> GetAllCourses()
        {
            try
            {
                IQueryable<Course> courses =
                    this.courseService.RetrieveAllCourses();

                return Ok(courses);
            }
            catch (CourseDependencyException courseDependencyException)
            {
                return Problem(courseDependencyException.Message);
            }
            catch (CourseServiceException courseServiceException)
            {
                return Problem(courseServiceException.Message);
            }
        }

        [HttpGet("{CourseId}")]
        public async ValueTask<ActionResult<Course>> GetCourseAsync(Guid CourseId)
        {
            try
            {
                Course course = await this.courseService.RetrieveCourseById(CourseId);

                return Ok(course);
            }
            catch (CourseValidationException courseValidationException)
                when (courseValidationException.InnerException is NotFoundCourseException)
            {
                string innerMessage = GetInnerMessage(courseValidationException);

                return NotFound(innerMessage);
            }
            catch (CourseValidationException courseValidationException)
            {
                string innerMessage = GetInnerMessage(courseValidationException);

                return BadRequest(courseValidationException);
            }
            catch (CourseDependencyException courseValidationException)
            {
                return Problem(courseValidationException.Message);
            }
        }

        [HttpPut]
        public async ValueTask<ActionResult<Course>> PutCourseAsync(Course course)
        {
            try
            {
                Course updatedCourse =
                    await this.courseService.ModifyCourseAsync(course);

                return Ok(updatedCourse);
            }
            catch (CourseValidationException courseValidationException)
                when (courseValidationException.InnerException is NotFoundCourseException)
            {
                string innerMessage = GetInnerMessage(courseValidationException);

                return NotFound(innerMessage);
            }
            catch (CourseValidationException courseValidationException)
            {
                string innerMessage = GetInnerMessage(courseValidationException);

                return BadRequest(innerMessage);
            }
            catch (CourseDependencyException courseDependencyException)
                when (courseDependencyException.InnerException is LockedCourseException)
            {
                string innerMessage = GetInnerMessage(courseDependencyException);

                return Locked(innerMessage);
            }
            catch (CourseDependencyException courseDependencyException)
            {
                return Problem(courseDependencyException.Message);
            }
            catch (CourseServiceException courseServiceException)
            {
                return Problem(courseServiceException.Message);
            }
        }

        [HttpDelete("{CourseId}")]
        public async ValueTask<ActionResult<Course>> DeleteCourseAsync(Guid CourseId)
        {
            try
            {
                Course course =
                   await this.courseService.DeleteCourseAsync(CourseId);

                return Ok(course);
            }
            catch (CourseValidationException courseValidationException)
                when (courseValidationException.InnerException is NotFoundCourseException)
            {
                string innerMessage = GetInnerMessage(courseValidationException);

                return NotFound(innerMessage);
            }
            catch (CourseValidationException courseValidationException)
            {
                string innerMessage = GetInnerMessage(courseValidationException);

                return BadRequest(courseValidationException);
            }
            catch (CourseDependencyException courseValidationException)
            {
                return Problem(courseValidationException.Message);
            }
            catch (CourseServiceException courseServiceException)
            {
                return Problem(courseServiceException.Message);
            }
        }      
        
        public static string GetInnerMessage(Exception exception) =>
            exception.InnerException.Message;
    }
}
