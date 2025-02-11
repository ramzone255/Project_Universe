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

namespace Project_Universe.Application.src.Entities.Project.Queries.GetProjectList
{
    public class GetProjectListQueryHandler
        : IRequestHandler<GetProjectListQuery, GetProjectListVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectListQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetProjectListVm> Handle(GetProjectListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Project
                .ProjectTo<GetProjectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetProjectListVm { Project = entityQuery };
        }
    }
}
