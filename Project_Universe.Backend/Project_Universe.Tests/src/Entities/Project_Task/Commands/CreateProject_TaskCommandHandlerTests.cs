using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Entities.Project_Task.Commands.CreateProject_Task;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Tests.src.Entities.Project_Task.Common;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project_Task.Commands
{
    public class CreateProject_TaskCommandHandlerTests : Project_TaskTestCommandBase
    {
        [Fact]
        public async Task CreateProject_TaskCommandHandler_Success()
        {
            var handler = new CreateProject_TaskCommandHandler(Context);
            var id_project = 1;
            var id_task = 1;
            var id_project_task = await handler.Handle(
                new CreateProject_TaskCommand
                {
                    id_project = id_project,
                    id_task = id_task
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Project_Task.SingleOrDefaultAsync(entity =>
               entity.id_project_task == id_project_task &&
               entity.id_project == id_project &&
               entity.id_task == id_task));
        }
    }
}
