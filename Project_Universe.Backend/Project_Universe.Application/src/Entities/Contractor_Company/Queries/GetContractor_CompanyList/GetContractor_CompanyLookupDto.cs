using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Contractor_Company.Queries.GetContractor_CompanyList
{
    public class GetContractor_CompanyLookupDto : IMapWith<Domain.src.Entities.Contractor_Company>
    {
        public int id_contractor_company { get; set; }
        public string name_contractor_company { get; set; }
        public string description_contractor_company { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Contractor_Company, GetContractor_CompanyLookupDto>()
                .ForMember(noteDto => noteDto.id_contractor_company,
                opt => opt.MapFrom(note => note.id_contractor_company))
                .ForMember(noteDto => noteDto.name_contractor_company,
                opt => opt.MapFrom(note => note.name_contractor_company))
                .ForMember(noteDto => noteDto.description_contractor_company,
                opt => opt.MapFrom(note => note.description_contractor_company));
        }
    }
}
