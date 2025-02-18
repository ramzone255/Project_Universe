using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Project.Commands.UpdateProject;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Tests.src.Entities.Project.Common;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project.Commands
{
    public class UpdateProjectCommandHandlerTests : ProjectTestCommandBase
    {
        [Fact]
        public async Task UpdateProjectCommandHandler_Success()
        {
            var handler = new UpdateProjectCommandHandler(Context);
            var updatedName_project = "Никита";
            var updatedId_contractor_company = 1;
            var updatedId_customer_company = 1;
            var updatedId_priority = 1;
            var updatedEnd_date_project = DateTime.Now;

            await handler.Handle(new UpdateProjectCommand
            {
                id_project = ProjectContextFactory.id_project_for_update,
                name_project = updatedName_project,
                end_date_project = updatedEnd_date_project,
                id_contractor_company = updatedId_contractor_company,
                id_customer_company = updatedId_customer_company,
                id_priority = updatedId_priority
            }, CancellationToken.None);

            Assert.NotNull(await Context.Project.SingleOrDefaultAsync(entity =>
            entity.id_project == ProjectContextFactory.id_project_for_update &&
            entity.name_project == updatedName_project &&
            entity.end_date_project == updatedEnd_date_project &&
            entity.id_contractor_company == updatedId_contractor_company &&
            entity.id_customer_company == updatedId_customer_company &&
            entity.id_priority == updatedId_priority));
        }

        [Fact]
        public async Task UpdateProjectCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateProjectCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateProjectCommand
                {
                    id_project = 5
                },
                CancellationToken.None));
        }
    }
}
