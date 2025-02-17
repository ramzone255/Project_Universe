using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Status.Queries.GetStatusList
{
    public class GetStatusListQueryValidator : AbstractValidator<GetStatusListQuery>
    {
        public GetStatusListQueryValidator()
        {
            RuleFor(entity => entity.id_status);
        }
    }
}
