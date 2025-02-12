using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Entities.Task_Entity.Commands.CreateTask;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Project_Universe.Tests.src.Entities.Task_Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Entity.Commands
{
    public class CreateTaskCommandHandlerTests : TaskTestCommandBase
    {
        [Fact]
        public async Task CreateTaskCommandHandler_Success()
        {
            var handler = new CreateTaskCommandHandler(Context);
            var name_task = "Demo";
            var comment = "DemoCom";
            var id_status = 1;
            var id_priority = 1;

            var id_task = await handler.Handle(
                new CreateTaskCommand
                {
                    name_task = name_task,
                    comment = comment,
                    id_status = id_status,
                    id_priority = id_priority
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Task.SingleOrDefaultAsync(entity =>
               entity.id_task == id_task &&
               entity.name_task == name_task &&
               entity.comment == comment &&
               entity.id_status == id_status &&
               entity.id_priority == id_priority));
        }
    }
}
