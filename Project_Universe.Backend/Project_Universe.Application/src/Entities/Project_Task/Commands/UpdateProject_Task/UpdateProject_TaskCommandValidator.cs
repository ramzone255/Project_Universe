using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Commands.UpdateProject_Task
{
    public class UpdateProject_TaskCommandValidator : AbstractValidator<UpdateProject_TaskCommand>
    {
        public UpdateProject_TaskCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_project_task).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_project);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_task);
        }
    }
}
