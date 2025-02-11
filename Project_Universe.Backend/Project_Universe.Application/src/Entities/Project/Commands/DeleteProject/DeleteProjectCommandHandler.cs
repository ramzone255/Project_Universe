using MediatR;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler
        : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProject_UniverseDbContext _dbContext;

        public DeleteProjectCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Project
                .FindAsync(new object[] { request.id_project }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Project), request.id_project);
            }
            _dbContext.Project.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
