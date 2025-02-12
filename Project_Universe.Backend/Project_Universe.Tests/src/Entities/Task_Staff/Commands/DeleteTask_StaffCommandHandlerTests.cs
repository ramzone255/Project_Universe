using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Application.src.Entities.Task_Staff.Commands.DeleteTask_Staff;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Project_Universe.Tests.src.Entities.Task_Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Staff.Commands
{
    public class DeleteTask_StaffCommandHandlerTests : Task_StaffTestCommandBase
    {
        [Fact]
        public async Task DeleteTask_StaffCommandHandler_Success()
        {
            var handler = new DeleteTask_StaffCommandHandler(Context);

            await handler.Handle(new DeleteTask_StaffCommand
            {
                id_task_staff = Task_StaffContextFactory.id_task_staff_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Task_Staff.SingleOrDefault(entity =>
            entity.id_task_staff == Task_StaffContextFactory.id_task_staff_for_delete));
        }

        [Fact]
        public async Task DeleteTask_StaffCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteTask_StaffCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteTask_StaffCommand
                {
                    id_task_staff = 5
                },
                CancellationToken.None));
        }
    }
}
