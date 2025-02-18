using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Contractor_Company.Queries.GetContractor_CompanyList
{
    public class GetContractor_CompanyListQuery : IRequest<GetContractor_CompanyListVm>
    {
        public int id_contractor_company { get; set; }
    }
}
