using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Queries.GetProjectList
{
    public class GetProjectLookupDto : IMapWith<Domain.src.Entities.Project>
    {
        public int id_project { get; set; }
        public string name_project { get; set; }
        public DateTime start_date_project { get; set; }
        public DateTime? end_date_project { get; set; }
        public int id_contractor_company { get; set; }
        public string name_contractor_company { get; set; }
        public int id_customer_company { get; set; }
        public string name_customer_company { get; set; }
        public int id_priority { get; set; }
        public string name_priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Project, GetProjectLookupDto>()
                .ForMember(noteDto => noteDto.id_project,
                opt => opt.MapFrom(note => note.id_project))
                .ForMember(noteDto => noteDto.name_project,
                opt => opt.MapFrom(note => note.name_project))
                .ForMember(noteDto => noteDto.start_date_project,
                opt => opt.MapFrom(note => note.start_date_project))
                .ForMember(noteDto => noteDto.end_date_project,
                opt => opt.MapFrom(note => note.end_date_project))
                .ForMember(noteDto => noteDto.id_contractor_company,
                opt => opt.MapFrom(note => note.id_contractor_company))
                .ForMember(noteDto => noteDto.id_customer_company,
                opt => opt.MapFrom(note => note.id_customer_company))
                .ForMember(noteDto => noteDto.id_priority,
                opt => opt.MapFrom(note => note.id_priority))
                .ForMember(noteDto => noteDto.name_contractor_company,
                opt => opt.MapFrom(note => note.Contractor_Company.name_contractor_company))
                .ForMember(noteDto => noteDto.name_customer_company,
                opt => opt.MapFrom(note => note.Customer_Company.name_customer_company))
                .ForMember(noteDto => noteDto.name_priority,
                opt => opt.MapFrom(note => note.Priority.name_priority));
        }
    }
}
