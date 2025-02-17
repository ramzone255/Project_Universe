using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Status.Queries.GetStatusList
{
    public class GetStatusListQuery : IRequest<GetStatusListVm>
    {
        public int id_status { get; set; }
    }
}
