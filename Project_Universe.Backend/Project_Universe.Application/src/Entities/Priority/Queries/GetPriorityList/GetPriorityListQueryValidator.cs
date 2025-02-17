using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Priority.Queries.GetPriorityList
{
    public class GetPriorityListQueryValidator : AbstractValidator<GetPriorityListQuery>
    {
        public GetPriorityListQueryValidator()
        {
            RuleFor(entity => entity.id_priority);
        }
    }
}
