using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffDetails
{
    public class GetTask_StaffDetailsQueryValidator : AbstractValidator<GetTask_StaffDetailsQuery>
    {
        public GetTask_StaffDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_task_staff).NotEmpty();
        }
    }
}
