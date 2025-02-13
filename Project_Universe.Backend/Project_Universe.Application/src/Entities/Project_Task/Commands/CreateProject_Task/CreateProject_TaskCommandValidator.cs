using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Commands.CreateProject_Task
{
    public class CreateProject_TaskCommandValidator : AbstractValidator<CreateProject_TaskCommand>
    {
        public CreateProject_TaskCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.id_project);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_task);
        }
    }
}
