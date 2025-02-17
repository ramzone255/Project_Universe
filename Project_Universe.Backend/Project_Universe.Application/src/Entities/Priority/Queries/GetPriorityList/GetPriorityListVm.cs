using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Priority.Queries.GetPriorityList
{
    public class GetPriorityListVm
    {
        public IList<GetPriorityLookupDto> Priority { get; set; }
    }
}
