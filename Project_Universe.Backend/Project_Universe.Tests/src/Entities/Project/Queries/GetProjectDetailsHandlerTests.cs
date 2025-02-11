using AutoMapper;
using Project_Universe.Application.src.Entities.Project.Queries.GetProjectDetails;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
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
    public class GetProjectDetailsHandlerTests
    {
        private readonly Project_UniverseDbContext Context;
        private readonly IMapper Mapper;
        public GetProjectDetailsHandlerTests(ProjectQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetProjectDetailsQueryHandler_Success()
        {
            var handler = new GetProjectDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetProjectDetailsQuery
                {
                    id_project = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<GetProjectDetailsVm>();
            result.name_project.ShouldBe("Alfa");
        }
    }
}
