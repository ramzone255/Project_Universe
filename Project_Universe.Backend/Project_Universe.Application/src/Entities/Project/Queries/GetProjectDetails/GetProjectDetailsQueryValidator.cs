using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Queries.GetProjectDetails
{
    public class GetProjectDetailsQueryValidator : AbstractValidator<GetProjectDetailsQuery>
    {
        public GetProjectDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_project).NotEmpty();
        }
    }
}
