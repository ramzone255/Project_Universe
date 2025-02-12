using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Application.src.Entities.Task_Entity.Commands.UpdateTask;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Project_Universe.Tests.src.Entities.Task_Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Entity.Commands
{
    public class UpdateTaskCommandHandlerTests : TaskTestCommandBase
    {
        [Fact]
        public async Task UpdateTaskCommandHandler_Success()
        {
            var handler = new UpdateTaskCommandHandler(Context);
            var updatedName_task = "Digma";
            var updatedComment = "DigmaCom";
            var updatedId_priority = 1;
            var updatedId_status = 1;

            await handler.Handle(new UpdateTaskCommand
            {
                id_task = TaskContextFactory.id_task_for_update,
                name_task = updatedName_task,
                comment = updatedComment,
                id_priority = updatedId_priority,
                id_status = updatedId_status
            }, CancellationToken.None);

            Assert.NotNull(await Context.Task.SingleOrDefaultAsync(entity =>
            entity.id_task == TaskContextFactory.id_task_for_update &&
            entity.name_task == updatedName_task &&
            entity.comment == updatedComment &&
            entity.id_priority == updatedId_priority &&
            entity.id_status == updatedId_status));
        }

        [Fact]
        public async Task UpdateTaskCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateTaskCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateTaskCommand
                {
                    id_task = 5
                },
                CancellationToken.None));
        }
    }
}
