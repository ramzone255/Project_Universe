using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails
{
    public class GetStaffDetailsQueryValidator : AbstractValidator<GetStaffDetailsQuery>
    {
        public GetStaffDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_staff).NotEmpty();
        }
    }
}
