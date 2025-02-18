using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Contractor_Company.Queries.GetContractor_CompanyList
{
    public class GetContractor_CompanyListQueryValidator : AbstractValidator<GetContractor_CompanyListQuery>
    {
        public GetContractor_CompanyListQueryValidator()
        {
            RuleFor(entity => entity.id_contractor_company);
        }
    }
}
