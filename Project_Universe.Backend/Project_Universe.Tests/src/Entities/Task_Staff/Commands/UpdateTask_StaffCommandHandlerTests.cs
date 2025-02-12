using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Application.src.Entities.Task_Staff.Commands.UpdateTask_Staff;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Project_Universe.Tests.src.Entities.Task_Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Staff.Commands
{
    public class UpdateTask_StaffCommandHandlerTests : Task_StaffTestCommandBase
    {
        [Fact]
        public async Task UpdateTask_StaffCommandHandler_Success()
        {
            var handler = new UpdateTask_StaffCommandHandler(Context);
            var updatedId_task = 1;
            var updatedId_staff = 1;

            await handler.Handle(new UpdateTask_StaffCommand
            {
                id_task_staff = Task_StaffContextFactory.id_task_staff_for_update,
                id_task = updatedId_task,
                id_staff = updatedId_staff
            }, CancellationToken.None);

            Assert.NotNull(await Context.Task_Staff.SingleOrDefaultAsync(entity =>
            entity.id_task_staff == Task_StaffContextFactory.id_task_staff_for_update &&
            entity.id_task == updatedId_task &&
            entity.id_staff == updatedId_staff));
        }

        [Fact]
        public async Task UpdateTask_StaffCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateTask_StaffCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateTask_StaffCommand
                {
                    id_task_staff = 5
                },
                CancellationToken.None));
        }
    }
}
