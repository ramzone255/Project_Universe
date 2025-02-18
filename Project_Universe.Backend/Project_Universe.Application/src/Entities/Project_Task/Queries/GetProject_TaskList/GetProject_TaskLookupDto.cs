using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskList
{
    public class GetProject_TaskLookupDto : IMapWith<Domain.src.Entities.Project_Task>
    {
        public int id_project_task { get; set; }
        public int? id_task { get; set; }
        public string? name_task { get; set; }
        public int? id_project { get; set; }
        public string? name_project { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Project_Task, GetProject_TaskLookupDto>()
                .ForMember(noteDto => noteDto.id_project_task,
                opt => opt.MapFrom(note => note.id_project_task))
                .ForMember(noteDto => noteDto.id_task,
                opt => opt.MapFrom(note => note.id_task))
                .ForMember(noteDto => noteDto.id_project,
                opt => opt.MapFrom(note => note.id_project))
                .ForMember(noteDto => noteDto.name_project,
                opt => opt.MapFrom(note => note.Project.name_project))
                .ForMember(noteDto => noteDto.name_task,
                opt => opt.MapFrom(note => note.Task.name_task));
        }
    }
}
