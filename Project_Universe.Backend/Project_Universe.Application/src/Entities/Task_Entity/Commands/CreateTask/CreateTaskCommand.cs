using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Entity.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string name_task { get; set; }
        public string comment { get; set; }
        public int id_status { get; set; }
        public int id_priority { get; set; }
    }
}
