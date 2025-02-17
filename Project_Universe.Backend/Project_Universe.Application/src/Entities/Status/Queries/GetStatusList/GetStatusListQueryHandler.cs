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

namespace Project_Universe.Application.src.Entities.Status.Queries.GetStatusList
{
    public class GetStatusListQueryHandler
        : IRequestHandler<GetStatusListQuery, GetStatusListVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetStatusListQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetStatusListVm> Handle(GetStatusListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Status
                .ProjectTo<GetStatusLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetStatusListVm { Status = entityQuery };
        }
    }
}
