using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails
{
    public class GetStaffDetailsHandler
        : IRequestHandler<GetStaffDetailsQuery, GetStaffDetailsVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStaffDetailsHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GetStaffDetailsVm> Handle(GetStaffDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Staff
                .FirstOrDefaultAsync(note =>
                note.id_staff == request.id_staff, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Staff), request.id_staff);
            }
            return _mapper.Map<GetStaffDetailsVm>(entity);
        }
    }
}
