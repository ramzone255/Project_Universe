using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Commands.UpdateTask_Staff
{
    public class UpdateTask_StaffCommand : IRequest
    {
        public int id_task_staff { get; set; }

        public int? id_task { get; set; }
        public int? id_staff { get; set; }
    }
}
