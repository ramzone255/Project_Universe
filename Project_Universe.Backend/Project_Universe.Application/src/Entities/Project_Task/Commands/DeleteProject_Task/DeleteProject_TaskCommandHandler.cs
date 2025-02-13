using MediatR;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Commands.DeleteProject_Task
{
    public class DeleteProject_TaskCommandHandler
        : IRequestHandler<DeleteProject_TaskCommand>
    {
        private readonly IProject_UniverseDbContext _dbContext;

        public DeleteProject_TaskCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteProject_TaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Project_Task
                .FindAsync(new object[] { request.id_project_task }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Project_Task), request.id_project_task);
            }
            _dbContext.Project_Task.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
