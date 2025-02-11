using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler :
        IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        public UpdateProjectCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Project.FirstOrDefaultAsync(note =>
                    note.id_project == request.id_project, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Project), request.id_project);
            }

            entity.name_project = request.name_project;
            entity.end_date_project = request.end_date_project;
            entity.id_contractor_company = request.id_contractor_company;
            entity.id_customer_company = request.id_customer_company;
            entity.id_priority = request.id_priority;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
