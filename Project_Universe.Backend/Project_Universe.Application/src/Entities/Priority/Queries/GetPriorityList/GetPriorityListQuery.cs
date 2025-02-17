using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Priority.Queries.GetPriorityList
{
    public class GetPriorityListQuery : IRequest<GetPriorityListVm>
    {
        public int id_priority { get; set; }
    }
}
