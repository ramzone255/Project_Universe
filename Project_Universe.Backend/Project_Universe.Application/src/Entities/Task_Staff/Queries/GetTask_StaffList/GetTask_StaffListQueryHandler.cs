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

namespace Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffList
{
    public class GetTask_StaffListQueryHandler
        : IRequestHandler<GetTask_StaffListQuery, GetTask_StaffListVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetTask_StaffListQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetTask_StaffListVm> Handle(GetTask_StaffListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Task_Staff
                .ProjectTo<GetTask_StaffLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetTask_StaffListVm { Task_Staff = entityQuery };
        }
    }
}
