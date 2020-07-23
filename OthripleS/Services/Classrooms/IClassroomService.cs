// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------
using OtripleS.Web.Api.Models.Classrooms;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OtripleS.Web.Api.Services.Classrooms
{
    public interface IClassroomService 
    {
        IQueryable<Classroom> RetrieveAllClassrooms();
        ValueTask<Classroom> RetrieveClassroomById(Guid classroomId);
        ValueTask<Classroom> ModifyClassroomAsync(Classroom classroom);
        ValueTask<Classroom> CreateClassroomAsync(Classroom classroom);
        ValueTask<Classroom> DeleteClassroomAsync(Guid classroomId);
    }
}
