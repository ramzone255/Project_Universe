using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffList
{
    public class GetTask_StaffListVm
    {
        public IList<GetTask_StaffLookupDto> Task_Staff { get; set; }
    }
}
