using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Project_Task.Commands.DeleteProject_Task;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Tests.src.Entities.Project_Task.Common;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project_Task.Commands
{
    public class DeleteProject_TaskCommandHandlerTests : Project_TaskTestCommandBase
    {
        [Fact]
        public async Task DeleteProject_TaskCommandHandler_Success()
        {
            var handler = new DeleteProject_TaskCommandHandler(Context);

            await handler.Handle(new DeleteProject_TaskCommand
            {
                id_project_task = Project_TaskContextFactory.id_project_task_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Project_Task.SingleOrDefault(entity =>
            entity.id_project_task == Project_TaskContextFactory.id_project_task_for_delete));
        }

        [Fact]
        public async Task DeleteProject_TaskCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteProject_TaskCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteProject_TaskCommand
                {
                    id_project_task = 5
                },
                CancellationToken.None));
        }
    }
}
