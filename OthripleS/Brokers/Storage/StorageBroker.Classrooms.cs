// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OtripleS.Web.Api.Models.Classrooms;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OtripleS.Web.Api.Brokers.Storage
{
    public partial class StorageBroker
    {
        public DbSet<Classroom> Classrooms { get; set; }

        public async ValueTask<Classroom> InsertClassroomAsync(
            Classroom classroom)
        {
            EntityEntry<Classroom> entityEntry = 
                await this.Classrooms.AddAsync(classroom);
            await this.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public IQueryable<Classroom> SelectAllClassrooms() => 
            this.Classrooms.AsQueryable();

        public ValueTask<Classroom> SelectClassroomByIdAsync(Guid classroomId)
        {
            this.ChangeTracker.QueryTrackingBehavior = new QueryTrackingBehavior();

            return this.Classrooms.FindAsync(classroomId);
        }

        public async ValueTask<Classroom> UpdateClassroomAsync(Classroom classroom)
        {
            EntityEntry<Classroom> entityEntry = this.Classrooms.Update(classroom);
            await this.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<Classroom> DeleteClassroomAsync(Classroom classroom)
        {
            EntityEntry<Classroom> entityEntry = this.Remove(classroom);
            await this.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
