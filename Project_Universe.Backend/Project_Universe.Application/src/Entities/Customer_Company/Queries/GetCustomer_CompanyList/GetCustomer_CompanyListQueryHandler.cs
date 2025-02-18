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

namespace Project_Universe.Application.src.Entities.Customer_Company.Queries.GetCustomer_CompanyList
{
    public class GetCustomer_CompanyListQueryHandler
        : IRequestHandler<GetCustomer_CompanyListQuery, GetCustomer_CompanyListVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCustomer_CompanyListQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetCustomer_CompanyListVm> Handle(GetCustomer_CompanyListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Customer_Company
                .ProjectTo<GetCustomer_CompanyLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetCustomer_CompanyListVm { Customer_Company = entityQuery };
        }
    }
}
