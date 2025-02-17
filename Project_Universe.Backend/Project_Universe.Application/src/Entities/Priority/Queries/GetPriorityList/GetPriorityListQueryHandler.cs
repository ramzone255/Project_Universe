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

namespace Project_Universe.Application.src.Entities.Priority.Queries.GetPriorityList
{
    public class GetPriorityListQueryHandler
        : IRequestHandler<GetPriorityListQuery, GetPriorityListVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPriorityListQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetPriorityListVm> Handle(GetPriorityListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Priority
                .ProjectTo<GetPriorityLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetPriorityListVm { Priority = entityQuery };
        }
    }
}
