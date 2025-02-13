using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskDetails
{
    public class GetProject_TaskDetailsQuery : IRequest<GetProject_TaskDetailsVm>
    {
        public int id_project_task { get; set; }
    }
}
