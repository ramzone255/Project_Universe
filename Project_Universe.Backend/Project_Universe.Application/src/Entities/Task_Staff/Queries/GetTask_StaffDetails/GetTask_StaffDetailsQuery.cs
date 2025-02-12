using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffDetails
{
    public class GetTask_StaffDetailsQuery : IRequest<GetTask_StaffDetailsVm>
    {
        public int id_task_staff { get; set; }
    }
}
