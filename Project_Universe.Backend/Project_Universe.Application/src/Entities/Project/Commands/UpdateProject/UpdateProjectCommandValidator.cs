using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.name_project).MaximumLength(50).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_contractor_company).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_customer_company).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_priority).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.end_date_project);
        }
    }
}
