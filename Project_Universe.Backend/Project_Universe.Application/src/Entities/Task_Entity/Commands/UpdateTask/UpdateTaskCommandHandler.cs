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

namespace Project_Universe.Application.src.Entities.Task_Entity.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler :
        IRequestHandler<UpdateTaskCommand>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        public UpdateTaskCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Task.FirstOrDefaultAsync(note =>
                    note.id_task == request.id_task, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Task), request.id_task);
            }

            entity.name_task = request.name_task;
            entity.comment = request.comment;
            entity.id_status = request.id_status;
            entity.id_priority = request.id_priority;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
