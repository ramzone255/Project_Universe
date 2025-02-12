using AutoMapper;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffDetails;
using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Project_Universe.Tests.src.Entities.Task_Staff.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Staff.Queries
{
    [Collection("Task_StaffQueryCollection")]
    public class GetTask_StaffDetailsHandlerTests
    {
        private readonly Project_UniverseDbContext Context;
        private readonly IMapper Mapper;
        public GetTask_StaffDetailsHandlerTests(Task_StaffQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetTask_StaffDetailsQueryHandler_Success()
        {
            var handler = new GetTask_StaffDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetTask_StaffDetailsQuery
                {
                    id_task_staff = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<GetTask_StaffDetailsVm>();
            result.id_task.ShouldBe(null);
        }
    }
}
