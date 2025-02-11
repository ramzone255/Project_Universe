using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Entities.Project.Commands.CreateProject;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Tests.src.Entities.Project.Common;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project.Commands
{
    public class CreateProjectCommandHandlerTests : ProjectTestCommandBase
    {
        [Fact]
        public async Task CreateProjectCommandHandler_Success()
        {
            var handler = new CreateProjectCommandHandler(Context);
            var name_project = "Altus";
            var id_contractor_company = 1;
            var id_customer_company = 1;
            var id_priority = 1;

            var id_staff = await handler.Handle(
                new CreateProjectCommand
                {
                    name_project = name_project,
                    id_contractor_company = id_contractor_company,
                    id_customer_company = id_customer_company,
                    id_priority = id_priority
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Project.SingleOrDefaultAsync(entity =>
               entity.id_project == id_staff &&
               entity.name_project == name_project &&
               entity.id_contractor_company == id_contractor_company &&
               entity.id_customer_company == id_customer_company &&
               entity.id_priority == id_priority));
        }
    }
}
