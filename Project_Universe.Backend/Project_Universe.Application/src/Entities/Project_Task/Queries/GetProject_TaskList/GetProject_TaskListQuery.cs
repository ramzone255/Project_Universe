using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskList
{
    public class GetProject_TaskListQuery : IRequest<GetProject_TaskListVm>
    {
        public int id_project_task { get; set; }
    }
}
