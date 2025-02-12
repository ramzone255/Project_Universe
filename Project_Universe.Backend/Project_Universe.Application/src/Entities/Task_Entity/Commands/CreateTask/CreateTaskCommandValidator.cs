using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Entity.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.name_task).MaximumLength(50).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.comment).MaximumLength(250).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_status).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_priority).NotEmpty();
        }
    }
}
