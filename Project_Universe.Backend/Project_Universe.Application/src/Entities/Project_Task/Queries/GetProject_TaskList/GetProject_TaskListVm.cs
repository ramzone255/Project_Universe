using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskList
{
    public class GetProject_TaskListVm
    {
        public IList<GetProject_TaskLookupDto> Project_Task { get; set; }
    }
}
