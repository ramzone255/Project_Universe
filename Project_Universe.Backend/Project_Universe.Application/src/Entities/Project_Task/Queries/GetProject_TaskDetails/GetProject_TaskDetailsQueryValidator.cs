using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskDetails
{
    public class GetProject_TaskDetailsQueryValidator : AbstractValidator<GetProject_TaskDetailsQuery>
    {
        public GetProject_TaskDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_project_task).NotEmpty();
        }
    }
}
