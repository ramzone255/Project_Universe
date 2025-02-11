using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.name_project).MaximumLength(50).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.start_date_project).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.end_date_project);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_contractor_company).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_customer_company).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_priority).NotEmpty();
        }
    }
}
