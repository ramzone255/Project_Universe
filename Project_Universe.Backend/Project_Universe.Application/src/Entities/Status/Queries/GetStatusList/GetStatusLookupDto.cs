using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Status.Queries.GetStatusList
{
    public class GetStatusLookupDto : IMapWith<Domain.src.Entities.Status>
    {
        public int id_status { get; set; }
        public string name_status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Status, GetStatusLookupDto>()
                .ForMember(noteDto => noteDto.id_status,
                opt => opt.MapFrom(note => note.id_status))
                .ForMember(noteDto => noteDto.name_status,
                opt => opt.MapFrom(note => note.name_status));
        }
    }
}
