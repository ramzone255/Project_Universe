using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Entity.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_task).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.name_task).MaximumLength(50).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.comment).MaximumLength(250).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_priority).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_status).NotEmpty();
        }
    }
}
