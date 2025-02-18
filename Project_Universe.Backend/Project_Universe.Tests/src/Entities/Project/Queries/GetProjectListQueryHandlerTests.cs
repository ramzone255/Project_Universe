using AutoMapper;
using Project_Universe.Application.src.Entities.Project.Queries.GetProjectList;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Project.Common;
using Project_Universe.Tests.src.Entities.Staff.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project.Queries
{
    [Collection("ProjectQueryCollection")]
    public class GetProjectListQueryHandlerTests
    {
        private readonly Project_UniverseDbContext Context;
        private readonly IMapper Mapper;

        public GetProjectListQueryHandlerTests(ProjectQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProjectListQueryHandler_Success()
        {
            var handler = new GetProjectListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetProjectListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<GetProjectListVm>();
            result.Project.Count.ShouldBe(0); 
        }
    }
}
