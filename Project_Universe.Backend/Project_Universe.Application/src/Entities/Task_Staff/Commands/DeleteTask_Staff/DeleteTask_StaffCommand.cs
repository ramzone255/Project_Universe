using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Commands.DeleteTask_Staff
{
    public class DeleteTask_StaffCommand : IRequest
    {
        public int id_task_staff { get; set; }
    }
}
