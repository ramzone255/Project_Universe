using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffList;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Contractor_Company.Queries.GetContractor_CompanyList
{
    public class GetContractor_CompanyListQueryHandler
        : IRequestHandler<GetContractor_CompanyListQuery, GetContractor_CompanyListVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetContractor_CompanyListQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetContractor_CompanyListVm> Handle(GetContractor_CompanyListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Contractor_Company
                .ProjectTo<GetContractor_CompanyLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetContractor_CompanyListVm { Contractor_Company = entityQuery };
        }
    }
}
