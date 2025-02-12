using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffList
{
    public class GetTask_StaffListQueryValidator : AbstractValidator<GetTask_StaffListQuery>
    {
        public GetTask_StaffListQueryValidator()
        {
            RuleFor(entity => entity.id_task_staff);
        }
    }
}
