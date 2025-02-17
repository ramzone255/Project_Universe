using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Priority.Queries.GetPriorityList
{
    public class GetPriorityLookupDto : IMapWith<Domain.src.Entities.Priority>
    {
        public int id_priority { get; set; }
        public string name_priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Priority, GetPriorityLookupDto>()
                .ForMember(noteDto => noteDto.id_priority,
                opt => opt.MapFrom(note => note.id_priority))
                .ForMember(noteDto => noteDto.name_priority,
                opt => opt.MapFrom(note => note.name_priority));
        }
    }
}
