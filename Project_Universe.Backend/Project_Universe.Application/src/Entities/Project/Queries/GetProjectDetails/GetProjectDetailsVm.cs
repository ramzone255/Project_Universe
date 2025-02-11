using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project.Queries.GetProjectDetails
{
    public class GetProjectDetailsVm : IMapWith<Domain.src.Entities.Project>
    {
        public int id_project { get; set; }
        public string name_project { get; set; }
        public DateOnly start_date_project { get; set; }
        public DateOnly? end_date_project { get; set; }
        public int id_contractor_company { get; set; }
        public int id_customer_company { get; set; }
        public int id_priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Project, GetProjectDetailsVm>()
                .ForMember(noteVm => noteVm.id_project,
                opt => opt.MapFrom(note => note.id_project))
                .ForMember(noteVm => noteVm.name_project,
                opt => opt.MapFrom(note => note.name_project))
                .ForMember(noteVm => noteVm.start_date_project,
                opt => opt.MapFrom(note => note.start_date_project))
                .ForMember(noteVm => noteVm.end_date_project,
                opt => opt.MapFrom(note => note.end_date_project))
                .ForMember(noteVm => noteVm.id_contractor_company,
                opt => opt.MapFrom(note => note.id_contractor_company))
                .ForMember(noteVm => noteVm.id_customer_company,
                opt => opt.MapFrom(note => note.id_customer_company))
                .ForMember(noteVm => noteVm.id_priority,
                opt => opt.MapFrom(note => note.id_priority));
        }
    }
}
