// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OtripleS.Web.Api.Models.Classrooms;
using OtripleS.Web.Api.Models.Classrooms.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OtripleS.Web.Api.Services.Classrooms
{
    public partial class ClassroomService
    {
        private delegate ValueTask<Classroom> ReturningClassroomFunction();
        private delegate IQueryable<Classroom> ReturningQueryableClassroomFunction();

        private async ValueTask<Classroom> TryCatch(
            ReturningClassroomFunction returningClassroomFunction)
        {
            try
            {
                return await returningClassroomFunction();
            }
            catch (InvalidClassroomInputException invalidClassroomInputException)
            {
                throw CreateAndLogValidationException(invalidClassroomInputException);
            }
            catch (NotFoundClassroomException notFoundClassroomException)
            {
                throw CreateAndLogValidationException(notFoundClassroomException);
            }
            catch (NullClassroomException nullClassroomException)
            {
                throw CreateAndLogValidationException(nullClassroomException);
            }
            catch (SqlException sqlException)
            {
                throw CreateAndLogCriticalDependencyException(sqlException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedClassroomException =
                    new LockedClassroomException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyException(lockedClassroomException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw CreateAndLogDependencyException(dbUpdateException);
            }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }

        private IQueryable<Classroom> TryCatch(
            ReturningQueryableClassroomFunction returningQueryableClassroomFunction)
        {
            try
            {
                return returningQueryableClassroomFunction();
            }
            catch (SqlException sqlException)
            {
                throw CreateAndLogCriticalDependencyException(sqlException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedClassroomException =
                    new LockedClassroomException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyException(lockedClassroomException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw CreateAndLogDependencyException(dbUpdateException);
            }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }

        private ClassroomValidationException CreateAndLogValidationException(
            Exception exception)
        {
            var ClassroomValidationException = new ClassroomValidationException(exception);
            this.loggingBroker.LogError(ClassroomValidationException);

            return ClassroomValidationException;
        }

        private ClassroomDependencyException CreateAndLogCriticalDependencyException(
            Exception exception)
        {
            var ClassroomDependencyException = new ClassroomDependencyException(exception);
            this.loggingBroker.LogCritical(ClassroomDependencyException);

            return ClassroomDependencyException;
        }

        private ClassroomDependencyException CreateAndLogDependencyException(
            Exception exception)
        {
            var ClassroomDependencyException = new ClassroomDependencyException(exception);
            this.loggingBroker.LogError(ClassroomDependencyException);

            return ClassroomDependencyException;
        }

        private ClassroomServiceException CreateAndLogServiceException(
            Exception exception)
        {
            var ClassroomServiceException = new ClassroomServiceException(exception);
            this.loggingBroker.LogError(ClassroomServiceException);

            return ClassroomServiceException;
        }
    }
}
