using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Status.Queries.GetStatusList
{
    public class GetStatusListVm
    {
        public IList<GetStatusLookupDto> Status { get; set; }
    }
}
