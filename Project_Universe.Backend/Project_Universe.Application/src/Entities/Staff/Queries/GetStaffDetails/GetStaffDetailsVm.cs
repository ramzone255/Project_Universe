using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Domain.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails
{
    public class GetStaffDetailsVm : IMapWith<Domain.src.Entities.Staff>
    {
        public int id_staff { get; set; }
        public string name_staff { get; set; }
        public string lastname_staff { get; set; }
        public string patronymic_staff { get; set; }
        public string email_staff { get; set; }
        public int id_post { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Staff, GetStaffDetailsVm>()
                .ForMember(noteVm => noteVm.id_staff,
                opt => opt.MapFrom(note => note.id_staff))
                .ForMember(noteVm => noteVm.name_staff,
                opt => opt.MapFrom(note => note.name_staff))
                .ForMember(noteVm => noteVm.lastname_staff,
                opt => opt.MapFrom(note => note.lastname_staff))
                .ForMember(noteVm => noteVm.patronymic_staff,
                opt => opt.MapFrom(note => note.patronymic_staff))
                .ForMember(noteVm => noteVm.email_staff,
                opt => opt.MapFrom(note => note.email_staff))
                .ForMember(noteVm => noteVm.id_post,
                opt => opt.MapFrom(note => note.id_post));
        }
    }
}
