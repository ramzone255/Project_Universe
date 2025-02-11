using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Queries.GetProjectList
{
    public class GetProjectListQueryValidator : AbstractValidator<GetProjectListQuery>
    {
        public GetProjectListQueryValidator()
        {
            RuleFor(entity => entity.id_project);
        }
    }
}
