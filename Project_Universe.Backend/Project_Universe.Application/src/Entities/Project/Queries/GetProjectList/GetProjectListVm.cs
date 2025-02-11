using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Queries.GetProjectList
{
    public class GetProjectListVm
    {
        public IList<GetProjectLookupDto> Project { get; set; }
    }
}
