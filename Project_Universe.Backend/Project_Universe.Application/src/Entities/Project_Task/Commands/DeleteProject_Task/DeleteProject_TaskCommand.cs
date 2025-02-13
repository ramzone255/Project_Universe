using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Commands.DeleteProject_Task
{
    public class DeleteProject_TaskCommand : IRequest
    {
        public int id_project_task { get; set; }
    }
}
