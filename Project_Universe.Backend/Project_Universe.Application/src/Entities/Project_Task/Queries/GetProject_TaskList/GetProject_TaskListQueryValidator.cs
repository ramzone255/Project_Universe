using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskList
{
    public class GetProject_TaskListQueryValidator : AbstractValidator<GetProject_TaskListQuery>
    {
        public GetProject_TaskListQueryValidator()
        {
            RuleFor(entity => entity.id_project_task);
        }
    }
}
