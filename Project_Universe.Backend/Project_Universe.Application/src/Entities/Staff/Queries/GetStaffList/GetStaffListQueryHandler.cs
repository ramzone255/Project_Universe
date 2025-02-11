using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList
{
    public class GetStaffListQueryHandler 
        : IRequestHandler<GetStaffListQuery, GetStaffListVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetStaffListQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetStaffListVm> Handle(GetStaffListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Staff
                .ProjectTo<GetStaffLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetStaffListVm { Staff = entityQuery };
        }
    }
}
