using MediatR;
using Project_Universe.Application.src.Common.Exceptions;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Commands.DeleteTask_Staff
{
    public class DeleteTask_StaffCommandHandler
        : IRequestHandler<DeleteTask_StaffCommand>
    {
        private readonly IProject_UniverseDbContext _dbContext;

        public DeleteTask_StaffCommandHandler(IProject_UniverseDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteTask_StaffCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Task_Staff
                .FindAsync(new object[] { request.id_task_staff }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Task_Staff), request.id_task_staff);
            }
            _dbContext.Task_Staff.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
