using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Entity.Queries.GetTaskList
{
    public class GetTaskListVm
    {
        public IList<GetTaskLookupDto> Task { get; set; }
    }
}
