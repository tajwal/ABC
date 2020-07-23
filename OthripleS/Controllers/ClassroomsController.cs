// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OtripleS.Web.Api.Models.Classrooms;
using OtripleS.Web.Api.Models.Classrooms.Exceptions;
using OtripleS.Web.Api.Services.Classrooms;
using RESTFulSense.Controllers;
using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace OtripleS.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : RESTFulController
    {
        private readonly IClassroomService classroomService;

        public ClassroomsController(IClassroomService classroomService) =>
            this.classroomService = classroomService;

        [HttpPost]
        public async ValueTask<ActionResult<Classroom>> PostClassroomAsync(
           [FromBody] Classroom classroom)
        {
            try
            {
                Classroom persistedClassroom =
              await classroomService.CreateClassroomAsync(classroom);

                return Ok(persistedClassroom);
            }
            catch (ClassroomValidationException classroomValidationException)
                when (classroomValidationException.InnerException is AlreadyExistsClassroomException)
            {
                string innerMessage = GetInnerMessage(classroomValidationException);

                return Conflict(innerMessage);
            }
            catch (ClassroomValidationException classroomValidationException)
            {
                string innerMessage = GetInnerMessage(classroomValidationException);

                return BadRequest(innerMessage);
            }
            catch (ClassroomDependencyException classroomDependencyException)
            {
                return Problem(classroomDependencyException.Message);
            }
            catch (ClassroomServiceException classroomServiceException)
            {
                return Problem(classroomServiceException.Message);
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<Classroom>> GetAllClassrooms()
        {
            try
            {
                IQueryable<Classroom> classrooms =
                    classroomService.RetrieveAllClassrooms();

                return Ok(classrooms);
            }
            catch (ClassroomDependencyException classroomDependencyException)
            {
                return Problem(classroomDependencyException.Message);
            }
            catch (ClassroomServiceException classroomServiceException)
            {
                return Problem(classroomServiceException.Message);
            }
        }

        [HttpGet("{ClassroomId}")]
        public async ValueTask<ActionResult<Classroom>> GetClassroomByIdAsync
            (Guid ClassroomId)
        {
            try
            {
                Classroom classrooms =
                   await  classroomService.RetrieveClassroomById(ClassroomId);

                return Ok(classrooms);
            }
            catch (ClassroomValidationException classroomValidationException)
                when (classroomValidationException.InnerException is NotFoundClassroomException)
            {
                string innerMessage = GetInnerMessage(classroomValidationException);

                return NotFound(innerMessage);
            }
            catch (ClassroomValidationException classroomValidationException)
            {
                string innerMessage = GetInnerMessage(classroomValidationException);

                return BadRequest(classroomValidationException);
            }
            catch (ClassroomDependencyException classroomDependencyException)
            {
                return Problem(classroomDependencyException.Message);
            }
        }

        [HttpPut]
        public async ValueTask<ActionResult<Classroom>> PutClassroomAsync(
            Classroom   classroom)
        {
            try
            {
                Classroom updateClassroom =
                await this.classroomService.ModifyClassroomAsync(classroom);

                return Ok(updateClassroom);
            }
            catch (ClassroomValidationException classroomValidationException)
                when (classroomValidationException.InnerException is NotFoundClassroomException)
            {
                string innerMessage = GetInnerMessage(classroomValidationException);

                return Conflict(innerMessage);
            }
            catch (ClassroomValidationException classroomValidationException)
            {
                string innerMessage = GetInnerMessage(classroomValidationException);

                return BadRequest(innerMessage);
            }
            catch (ClassroomDependencyException classroomDependencyException)
                when(classroomDependencyException.InnerException is LockedClassroomException){
                string innerMessage = GetInnerMessage(classroomDependencyException);

                return Locked(innerMessage);
                }   
            catch (ClassroomDependencyException classroomDependencyException)
            {
                return Problem(classroomDependencyException.Message);
            }
            catch (ClassroomServiceException classroomServiceException)
            {
                return Problem(classroomServiceException.Message);
            }
        }
        
        [HttpDelete("{classroomId}")]
        public async ValueTask<ActionResult<Classroom>> DeleteClassroomAsync(Guid classroomId)
        {
            try
            {
                Classroom classroom =
                    await classroomService.DeleteClassroomAsync(classroomId);

                return Ok(classroom);
            }
            catch (ClassroomValidationException classroomValidationException)
                when (classroomValidationException.InnerException is NotFoundClassroomException)
            {
                string innerMessage = GetInnerMessage(classroomValidationException);

                return Conflict(innerMessage);
            }
            catch (ClassroomValidationException classroomValidationException)
                when (classroomValidationException.InnerException is NotFoundClassroomException)
            {
                string innerMessage = GetInnerMessage(classroomValidationException);

                return NotFound(innerMessage);
            }
            catch (ClassroomValidationException classroomValidationException)
            {
                string innerMessage = GetInnerMessage(classroomValidationException.InnerException);

                return BadRequest(innerMessage);
            }
            catch (ClassroomDependencyException classroomDependencyException)
            {
                return Problem(classroomDependencyException.Message);
            }
            catch (ClassroomServiceException classroomServiceException)
            {
                return Problem(classroomServiceException.Message);
            }
        }
        
        public static string GetInnerMessage(Exception exception) =>
            exception.InnerException.Message;
    }
}
