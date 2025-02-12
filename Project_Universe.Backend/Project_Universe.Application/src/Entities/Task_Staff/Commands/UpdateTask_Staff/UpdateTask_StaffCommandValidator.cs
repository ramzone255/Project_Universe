using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Commands.UpdateTask_Staff
{
    public class UpdateTask_StaffCommandValidator : AbstractValidator<UpdateTask_StaffCommand>
    {
        public UpdateTask_StaffCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_task_staff).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_staff);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_task);
        }
    }
}
