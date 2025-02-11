using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Staff.Commands
{
    public class UpdateStaffCommandHandlerTests : StaffTestCommandBase
    {
        [Fact]
        public async Task UpdateStaffCommandHandler_Success()
        {
            var handler = new UpdateStaffCommandHandler(Context);
            var updatedName_staff = "Никита";
            var updatedLastname_staff = "Орлов";
            var updatedPatronymic_staff = "Владимирович";
            var updatedEmail_staff = "orlov@example.com";
            var updatedId_post = 1;

            await handler.Handle(new UpdateStaffCommand
            {
                id_staff = StaffContextFactory.id_staff_for_update,
                name_staff = updatedName_staff,
                lastname_staff = updatedLastname_staff,
                patronymic_staff = updatedPatronymic_staff,
                email_staff = updatedEmail_staff,
                id_post = updatedId_post
            }, CancellationToken.None);

            Assert.NotNull(await Context.Staff.SingleOrDefaultAsync(entity =>
            entity.id_staff == StaffContextFactory.id_staff_for_update &&
            entity.name_staff == updatedName_staff &&
            entity.lastname_staff == updatedLastname_staff &&
            entity.patronymic_staff == updatedPatronymic_staff &&
            entity.email_staff == updatedEmail_staff &&
            entity.id_post == updatedId_post));
        }

        [Fact]
        public async Task UpdateStaffCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateStaffCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateStaffCommand
                {
                    id_staff = 5
                },
                CancellationToken.None));
        }
    }
}
