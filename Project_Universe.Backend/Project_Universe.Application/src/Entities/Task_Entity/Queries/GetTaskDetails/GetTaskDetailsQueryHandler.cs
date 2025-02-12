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

namespace Project_Universe.Application.src.Entities.Task_Entity.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler
        : IRequestHandler<GetTaskDetailsQuery, GetTaskDetailsVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GetTaskDetailsVm> Handle(GetTaskDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Task
                .FirstOrDefaultAsync(note =>
                note.id_task == request.id_task, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Task), request.id_task);
            }

            return _mapper.Map<GetTaskDetailsVm>(entity);
        }
    }
}
