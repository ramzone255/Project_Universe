using AutoMapper;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using Project_Universe.Application.src.Entities.Task_Entity.Queries.GetTaskList;
using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Project_Universe.Tests.src.Entities.Task_Entity.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Entity.Queries
{
    [Collection("TaskQueryCollection")]
    public class GetTaskListQueryHandlerTests
    {
        private readonly Project_UniverseDbContext Context;
        private readonly IMapper Mapper;

        public GetTaskListQueryHandlerTests(TaskQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTaskListQueryHandler_Success()
        {
            var handler = new GetTaskListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetTaskListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<GetTaskListVm>();
            result.Task.Count.ShouldBe(0);
        }
    }
}
