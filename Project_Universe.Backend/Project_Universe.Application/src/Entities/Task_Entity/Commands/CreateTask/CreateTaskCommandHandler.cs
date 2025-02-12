using MediatR;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Entity.Commands.CreateTask
{
    public class CreateTaskCommandHandler
        : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly IProject_UniverseDbContext _dbContext;

        public CreateTaskCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var tasks = new Domain.src.Entities.Task
            {
                name_task = request.name_task,
                comment = request.comment,
                id_priority = request.id_priority,
                id_status = request.id_status
            };

            await _dbContext.Task.AddAsync(tasks, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return tasks.id_task;
        }
    }
}
