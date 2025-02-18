using Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Contractor_Company.Queries.GetContractor_CompanyList
{
    public class GetContractor_CompanyListVm
    {
        public IList<GetContractor_CompanyLookupDto> Contractor_Company { get; set; }
    }
}
