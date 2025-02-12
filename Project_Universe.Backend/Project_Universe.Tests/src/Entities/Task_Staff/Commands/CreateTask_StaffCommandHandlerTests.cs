using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Entities.Task_Staff.Commands.CreateTask_Staff;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Project_Universe.Tests.src.Entities.Task_Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Staff.Commands
{
    public class CreateTask_StaffCommandHandlerTests : Task_StaffTestCommandBase
    {
        [Fact]
        public async Task CreateTask_StaffCommandHandler_Success()
        {
            var handler = new CreateTask_StaffCommandHandler(Context);
            var id_staff = 1;
            var id_task = 1;

            var id_task_staff = await handler.Handle(
                new CreateTask_StaffCommand
                {
                    id_staff = id_staff,
                    id_task = id_task
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Task_Staff.SingleOrDefaultAsync(entity =>
               entity.id_task_staff == id_task_staff &&
               entity.id_staff == id_staff &&
               entity.id_task == id_task));
        }
    }
}
