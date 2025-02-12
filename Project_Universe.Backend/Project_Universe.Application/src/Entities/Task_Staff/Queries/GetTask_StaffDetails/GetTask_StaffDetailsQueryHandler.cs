using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffDetails
{
    public class GetTask_StaffDetailsQueryHandler
        : IRequestHandler<GetTask_StaffDetailsQuery, GetTask_StaffDetailsVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTask_StaffDetailsQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GetTask_StaffDetailsVm> Handle(GetTask_StaffDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Task_Staff
                .FirstOrDefaultAsync(note =>
                note.id_task_staff == request.id_task_staff, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Task_Staff), request.id_task_staff);
            }

            return _mapper.Map<GetTask_StaffDetailsVm>(entity);
        }
    }
}
