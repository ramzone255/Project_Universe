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

namespace Project_Universe.Application.src.Entities.Task_Entity.Queries.GetTaskList
{
    public class GetTaskListQueryHandler
        : IRequestHandler<GetTaskListQuery, GetTaskListVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetTaskListQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetTaskListVm> Handle(GetTaskListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Task
                .ProjectTo<GetTaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetTaskListVm { Task = entityQuery };
        }
    }
}
