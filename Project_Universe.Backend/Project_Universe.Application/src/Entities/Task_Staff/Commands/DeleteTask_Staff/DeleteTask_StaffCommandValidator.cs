using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Commands.DeleteTask_Staff
{
    public class DeleteTask_StaffCommandValidator : AbstractValidator<DeleteTask_StaffCommand>
    {
        public DeleteTask_StaffCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_task_staff).NotEmpty();
        }
    }
}
