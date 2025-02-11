using AutoMapper;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Staff.Queries
{
    [Collection("StaffQueryCollection")]
    public class GetStaffDetailsHandlerTests
    {
        private readonly Project_UniverseDbContext Context;
        private readonly IMapper Mapper;
        public GetStaffDetailsHandlerTests(StaffQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetStaffDetailsQueryHandler_Success()
        {
            var handler = new GetStaffDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetStaffDetailsQuery
                {
                    id_staff = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<GetStaffDetailsVm>();
            result.name_staff.ShouldBe("Иван");
        }
    }
}
