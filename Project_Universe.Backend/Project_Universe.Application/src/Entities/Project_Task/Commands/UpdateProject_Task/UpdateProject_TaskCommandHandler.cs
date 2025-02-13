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

namespace Project_Universe.Application.src.Entities.Project_Task.Commands.UpdateProject_Task
{
    public class UpdateProject_TaskCommandHandler :
        IRequestHandler<UpdateProject_TaskCommand>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        public UpdateProject_TaskCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateProject_TaskCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Project_Task.FirstOrDefaultAsync(note =>
                    note.id_project_task == request.id_project_task, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Project_Task), request.id_project_task);
            }

            entity.id_project = request.id_project;
            entity.id_task = request.id_task;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
