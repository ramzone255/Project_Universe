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

namespace Project_Universe.Application.src.Entities.Project.Queries.GetProjectDetails
{
    public class GetProjectDetailsQueryHandler
        : IRequestHandler<GetProjectDetailsQuery, GetProjectDetailsVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectDetailsQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GetProjectDetailsVm> Handle(GetProjectDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Project
                .FirstOrDefaultAsync(note =>
                note.id_project == request.id_project, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Project), request.id_project);
            }

            return _mapper.Map<GetProjectDetailsVm>(entity);
        }
    }
}
