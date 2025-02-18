using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Customer_Company.Queries.GetCustomer_CompanyList
{
    public class GetCustomer_CompanyLookupDto : IMapWith<Domain.src.Entities.Customer_Company>
    {
        public int id_customer_company { get; set; }
        public string name_customer_company { get; set; }
        public string description_customer_company { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Customer_Company, GetCustomer_CompanyLookupDto>()
                .ForMember(noteDto => noteDto.id_customer_company,
                opt => opt.MapFrom(note => note.id_customer_company))
                .ForMember(noteDto => noteDto.name_customer_company,
                opt => opt.MapFrom(note => note.name_customer_company))
                .ForMember(noteDto => noteDto.description_customer_company,
                opt => opt.MapFrom(note => note.description_customer_company));
        }
    }
}
