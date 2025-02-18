using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Customer_Company.Queries.GetCustomer_CompanyList
{
    public class GetCustomer_CompanyListQuery : IRequest<GetCustomer_CompanyListVm>
    {
        public int id_customer_company { get; set; }
    }
}
