using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Commands.UpdateProject_Task
{
    public class UpdateProject_TaskCommand : IRequest
    {
        public int id_project_task { get; set; }
        public int? id_task { get; set; }
        public int? id_project { get; set; }
    }
}
