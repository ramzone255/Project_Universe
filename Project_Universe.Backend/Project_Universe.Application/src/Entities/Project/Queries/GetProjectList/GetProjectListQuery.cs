using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Queries.GetProjectList
{
    public class GetProjectListQuery : IRequest<GetProjectListVm>
    {
        public int id_project { get; set; }
    }
}
