using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Commands.CreateTask_Staff
{
    public class CreateTask_StaffCommandValidator : AbstractValidator<CreateTask_StaffCommand>
    {
        public CreateTask_StaffCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.id_staff);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_task);
        }
    }
}
