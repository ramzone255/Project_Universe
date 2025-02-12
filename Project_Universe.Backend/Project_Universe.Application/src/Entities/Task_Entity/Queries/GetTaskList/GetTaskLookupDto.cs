using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Task_Entity.Queries.GetTaskDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Entity.Queries.GetTaskList
{
    public class GetTaskLookupDto : IMapWith<Domain.src.Entities.Task>
    {
        public int id_task { get; set; }
        public string name_task { get; set; }
        public string comment { get; set; }
        public int id_status { get; set; }
        public int id_priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Task, GetTaskLookupDto>()
                .ForMember(noteVm => noteVm.id_task,
                opt => opt.MapFrom(note => note.id_task))
                .ForMember(noteVm => noteVm.name_task,
                opt => opt.MapFrom(note => note.name_task))
                .ForMember(noteVm => noteVm.comment,
                opt => opt.MapFrom(note => note.comment))
                .ForMember(noteVm => noteVm.id_status,
                opt => opt.MapFrom(note => note.id_status))
                .ForMember(noteVm => noteVm.id_priority,
                opt => opt.MapFrom(note => note.id_priority));
        }
    }
}
