using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffList
{
    public class GetTask_StaffLookupDto : IMapWith<Domain.src.Entities.Task_Staff>
    {
        public int id_task_staff { get; set; }
        public int? id_task { get; set; }
        public int? id_staff { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Task_Staff, GetTask_StaffLookupDto>()
                .ForMember(noteDto => noteDto.id_task_staff,
                opt => opt.MapFrom(note => note.id_task_staff))
                .ForMember(noteDto => noteDto.id_task,
                opt => opt.MapFrom(note => note.id_task))
                .ForMember(noteDto => noteDto.id_staff,
                opt => opt.MapFrom(note => note.id_staff));
        }
    }
}
