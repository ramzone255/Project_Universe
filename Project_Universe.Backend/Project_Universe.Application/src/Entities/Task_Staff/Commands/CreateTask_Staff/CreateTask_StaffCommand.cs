using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Commands.CreateTask_Staff
{
    public class CreateTask_StaffCommand : IRequest<int>
    {
        public int? id_task { get; set; }
        public int? id_staff { get; set; }
    }
}
