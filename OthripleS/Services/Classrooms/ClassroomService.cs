// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------
using OtripleS.Web.Api.Brokers.DateTimes;
using OtripleS.Web.Api.Brokers.Loggings;
using OtripleS.Web.Api.Brokers.Storage;
using OtripleS.Web.Api.Models.Classrooms;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OtripleS.Web.Api.Services.Classrooms
{
    public partial class ClassroomService : IClassroomService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public ClassroomService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker
            )
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public async ValueTask<Classroom> CreateClassroomAsync(Classroom classroom)
        {
            return await this.storageBroker.InsertClassroomAsync(classroom);   
        }

        public async ValueTask<Classroom> DeleteClassroomAsync(Guid classroomId)
        {
            Classroom classroom = await this.storageBroker.SelectClassroomByIdAsync(classroomId);
            
            return await this.storageBroker.DeleteClassroomAsync(classroom);   
        }

        public ValueTask<Classroom> ModifyClassroomAsync(Classroom classroom)
        {
            return this.storageBroker.UpdateClassroomAsync(classroom);
        }

        public IQueryable<Classroom> RetrieveAllClassrooms()
        {
            return this.storageBroker.SelectAllClassrooms();   
        }

        public async ValueTask<Classroom> RetrieveClassroomById(Guid classroomId)
        {
            return await this.storageBroker.SelectClassroomByIdAsync(classroomId);   
        }
    }
}
