using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Project.Commands.DeleteProject;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Tests.src.Entities.Project.Common;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project.Commands
{
    public class DeleteProjectCommandHandlerTests : ProjectTestCommandBase
    {
        [Fact]
        public async Task DeleteProjectCommandHandler_Success()
        {
            var handler = new DeleteProjectCommandHandler(Context);

            await handler.Handle(new DeleteProjectCommand
            {
                id_project = ProjectContextFactory.id_project_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Project.SingleOrDefault(entity =>
            entity.id_project == ProjectContextFactory.id_project_for_delete));
        }

        [Fact]
        public async Task DeleteProjectCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteProjectCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteProjectCommand
                {
                    id_project = 5
                },
                CancellationToken.None));
        }
    }
}
