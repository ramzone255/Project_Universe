using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Commands.DeleteProject_Task
{
    public class DeleteProject_TaskCommandValidator : AbstractValidator<DeleteProject_TaskCommand>
    {
        public DeleteProject_TaskCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_project_task).NotEmpty();
        }
    }
}
