using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Queries.GetProjectDetails
{
    public class GetProjectDetailsQuery : IRequest<GetProjectDetailsVm>
    {
        public int id_project { get; set; }
    }
}
