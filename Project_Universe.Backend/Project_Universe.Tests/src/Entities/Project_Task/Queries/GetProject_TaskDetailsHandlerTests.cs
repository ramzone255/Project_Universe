using AutoMapper;
using Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskDetails;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Project_Task.Common;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project_Task.Queries
{
    [Collection("Project_TaskQueryCollection")]
    public class GetProject_TaskDetailsHandlerTests
    {
        private readonly Project_UniverseDbContext Context;
        private readonly IMapper Mapper;
        public GetProject_TaskDetailsHandlerTests(Project_TaskQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetProject_TaskDetailsQueryHandler_Success()
        {
            var handler = new GetProject_TaskDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetProject_TaskDetailsQuery
                {
                    id_project_task = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<GetProject_TaskDetailsVm>();
            result.id_project.ShouldBe(null);
        }
    }
}
