using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Commands.CreateProject_Task
{
    public class CreateProject_TaskCommand : IRequest<int>
    {
        public int? id_task { get; set; }
        public int? id_project { get; set; }
    }
}
