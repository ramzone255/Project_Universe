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

namespace Project_Universe.Application.src.Entities.Task_Staff.Commands.UpdateTask_Staff
{
    public class UpdateTask_StaffCommandHandler :
        IRequestHandler<UpdateTask_StaffCommand>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        public UpdateTask_StaffCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateTask_StaffCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Task_Staff.FirstOrDefaultAsync(note =>
                    note.id_task_staff == request.id_task_staff, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Task_Staff), request.id_task_staff);
            }

            entity.id_staff = request.id_staff;
            entity.id_task = request.id_task;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
