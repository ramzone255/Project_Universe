using MediatR;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Commands.CreateProject_Task
{
    public class CreateProject_TaskCommandHandler
        : IRequestHandler<CreateProject_TaskCommand, int>
    {
        private readonly IProject_UniverseDbContext _dbContext;

        public CreateProject_TaskCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateProject_TaskCommand request, CancellationToken cancellationToken)
        {
            var project_tasks = new Domain.src.Entities.Project_Task
            {
                id_project = request.id_project,
                id_task = request.id_task
            };

            await _dbContext.Project_Task.AddAsync(project_tasks, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return project_tasks.id_project_task;
        }
    }
}
