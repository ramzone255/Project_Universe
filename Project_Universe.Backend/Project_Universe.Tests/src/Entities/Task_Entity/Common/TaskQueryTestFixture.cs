﻿using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Interfaces;
using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Entity.Common
{
    public class TaskQueryTestFixture : IDisposable
    {
        public Project_UniverseDbContext Context;
        public IMapper Mapper;

        public TaskQueryTestFixture()
        {
            Context = TaskContextFactory.Create();
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
            TaskContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("TaskQueryCollection")]
    public class QueryCollection : ICollectionFixture<TaskQueryTestFixture> { }
}
