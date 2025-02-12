using MediatR;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Commands.CreateTask_Staff
{
    public class CreateTask_StaffCommandHandler
        : IRequestHandler<CreateTask_StaffCommand, int>
    {
        private readonly IProject_UniverseDbContext _dbContext;

        public CreateTask_StaffCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateTask_StaffCommand request, CancellationToken cancellationToken)
        {
            var task_Staffs = new Domain.src.Entities.Task_Staff
            {
                id_task = request.id_task,
                id_staff = request.id_staff
            };

            await _dbContext.Task_Staff.AddAsync(task_Staffs, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task_Staffs.id_task_staff;
        }
    }
}
