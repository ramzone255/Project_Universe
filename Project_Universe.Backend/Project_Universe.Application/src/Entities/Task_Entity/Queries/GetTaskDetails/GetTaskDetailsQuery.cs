using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Entity.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery : IRequest<GetTaskDetailsVm>
    {
        public int id_task { get; set; }
    }
}
