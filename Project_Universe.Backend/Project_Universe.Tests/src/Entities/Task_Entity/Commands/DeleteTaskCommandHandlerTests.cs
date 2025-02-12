using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Application.src.Entities.Task_Entity.Commands.DeleteTask;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Project_Universe.Tests.src.Entities.Task_Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Entity.Commands
{
    public class DeleteTaskCommandHandlerTests : TaskTestCommandBase
    {
        [Fact]
        public async Task DeleteTaskCommandHandler_Success()
        {
            var handler = new DeleteTaskCommandHandler(Context);

            await handler.Handle(new DeleteTaskCommand
            {
                id_task = TaskContextFactory.id_task_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Task.SingleOrDefault(entity =>
            entity.id_task == TaskContextFactory.id_task_for_delete));
        }

        [Fact]
        public async Task DeleteTaskCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteTaskCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteTaskCommand
                {
                    id_task = 5
                },
                CancellationToken.None));
        }
    }
}
