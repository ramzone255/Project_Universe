using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Project_Task.Commands.UpdateProject_Task;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Tests.src.Entities.Project_Task.Common;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project_Task.Commands
{
    public class UpdateProject_TaskCommandHandlerTests : Project_TaskTestCommandBase
    {
        [Fact]
        public async Task UpdateProject_TaskCommandHandler_Success()
        {
            var handler = new UpdateProject_TaskCommandHandler(Context);
            var updatedId_project = 1;
            var updatedId_task = 1;

            await handler.Handle(new UpdateProject_TaskCommand
            {
                id_project_task = Project_TaskContextFactory.id_project_task_for_update,
                id_project = updatedId_project,
                id_task = updatedId_task
            }, CancellationToken.None);

            Assert.NotNull(await Context.Project_Task.SingleOrDefaultAsync(entity =>
            entity.id_project_task == Project_TaskContextFactory.id_project_task_for_update &&
            entity.id_project == updatedId_project &&
            entity.id_task == updatedId_task));
        }

        [Fact]
        public async Task UpdateProject_TaskCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateProject_TaskCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateProject_TaskCommand
                {
                    id_project_task = 5
                },
                CancellationToken.None));
        }
    }
}
