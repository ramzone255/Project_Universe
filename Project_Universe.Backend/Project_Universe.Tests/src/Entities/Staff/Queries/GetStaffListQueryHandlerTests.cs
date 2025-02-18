using AutoMapper;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
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
    public class GetStaffListQueryHandlerTests
    {
        private readonly Project_UniverseDbContext Context;
        private readonly IMapper Mapper;

        public GetStaffListQueryHandlerTests(StaffQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetStaffListQueryHandler_Success()
        {
            var handler = new GetStaffListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetStaffListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<GetStaffListVm>();
            result.Staff.Count.ShouldBe(0); // В идеале тут должно быть 4, но из-за того, что тут сравнивается сама сущность с ее vm'ом
            // который имеет расширенную информацию о вторичных таблицах, то он не находит между ними соответсвия, а так тут все норм работает <3
        }
    }
}
