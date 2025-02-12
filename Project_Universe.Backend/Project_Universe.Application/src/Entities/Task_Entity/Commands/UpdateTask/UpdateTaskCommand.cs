using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Entity.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest
    {
        public int id_task { get; set; }
        public string name_task { get; set; }
        public string comment { get; set; }
        public int id_status { get; set; }
        public int id_priority { get; set; }
    }
}
