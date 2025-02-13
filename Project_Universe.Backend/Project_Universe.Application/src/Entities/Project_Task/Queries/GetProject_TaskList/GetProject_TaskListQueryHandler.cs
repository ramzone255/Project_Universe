using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskList
{
    public class GetProject_TaskListQueryHandler
        : IRequestHandler<GetProject_TaskListQuery, GetProject_TaskListVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProject_TaskListQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetProject_TaskListVm> Handle(GetProject_TaskListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Project_Task
                .ProjectTo<GetProject_TaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetProject_TaskListVm { Project_Task = entityQuery };
        }
    }
}
