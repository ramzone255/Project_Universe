using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Interfaces;
using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project_Task.Common
{
    public class Project_TaskQueryTestFixture : IDisposable
    {
        public Project_UniverseDbContext Context;
        public IMapper Mapper;

        public Project_TaskQueryTestFixture()
        {
            Context = Project_TaskContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.ShouldMapMethod = (m => false);
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IProject_UniverseDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            Project_TaskContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("Project_TaskQueryCollection")]
    public class QueryCollection : ICollectionFixture<Project_TaskQueryTestFixture> { }
}
