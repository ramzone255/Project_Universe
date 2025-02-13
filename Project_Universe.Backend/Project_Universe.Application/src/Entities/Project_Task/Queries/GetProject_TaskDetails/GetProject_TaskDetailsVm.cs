using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskDetails
{
    public class GetProject_TaskDetailsVm : IMapWith<Domain.src.Entities.Project_Task>
    {
        public int id_project_task { get; set; }
        public int? id_task { get; set; }
        public int? id_project { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Project_Task, GetProject_TaskDetailsVm>()
                .ForMember(noteVm => noteVm.id_project_task,
                opt => opt.MapFrom(note => note.id_project_task))
                .ForMember(noteVm => noteVm.id_project,
                opt => opt.MapFrom(note => note.id_project))
                .ForMember(noteVm => noteVm.id_task,
                opt => opt.MapFrom(note => note.id_task));
        }
    }
}
