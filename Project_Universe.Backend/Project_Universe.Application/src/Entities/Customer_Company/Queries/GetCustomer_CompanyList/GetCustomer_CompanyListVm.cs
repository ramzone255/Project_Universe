using Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Customer_Company.Queries.GetCustomer_CompanyList
{
    public class GetCustomer_CompanyListVm
    {
        public IList<GetCustomer_CompanyLookupDto> Customer_Company { get; set; }
    }
}
