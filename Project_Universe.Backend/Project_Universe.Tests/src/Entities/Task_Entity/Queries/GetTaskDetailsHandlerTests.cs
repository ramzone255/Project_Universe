using AutoMapper;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Application.src.Entities.Task_Entity.Queries.GetTaskDetails;
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
    public class GetTaskDetailsHandlerTests
    {
        private readonly Project_UniverseDbContext Context;
        private readonly IMapper Mapper;
        public GetTaskDetailsHandlerTests(TaskQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetTaskDetailsQueryHandler_Success()
        {
            var handler = new GetTaskDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetTaskDetailsQuery
                {
                    id_task = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<GetTaskDetailsVm>();
            result.name_task.ShouldBe("Alfa");
        }
    }
}
