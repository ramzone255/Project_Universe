using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Customer_Company.Queries.GetCustomer_CompanyList
{
    public class GetCustomer_CompanyListQueryValidator : AbstractValidator<GetCustomer_CompanyListQuery>
    {
        public GetCustomer_CompanyListQueryValidator()
        {
            RuleFor(entity => entity.id_customer_company);
        }
    }
}
