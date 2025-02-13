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

namespace Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskDetails
{
    public class GetProject_TaskDetailsQueryHandler
        : IRequestHandler<GetProject_TaskDetailsQuery, GetProject_TaskDetailsVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProject_TaskDetailsQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GetProject_TaskDetailsVm> Handle(GetProject_TaskDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Project_Task
                .FirstOrDefaultAsync(note =>
                note.id_project_task == request.id_project_task, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Project_Task), request.id_project_task);
            }

            return _mapper.Map<GetProject_TaskDetailsVm>(entity);
        }
    }
}
