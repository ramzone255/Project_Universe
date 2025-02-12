using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffDetails
{
    public class GetTask_StaffDetailsVm : IMapWith<Domain.src.Entities.Task_Staff>
    {
        public int id_task_staff { get; set; }
        public int? id_task { get; set; }
        public int? id_staff { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Task_Staff, GetTask_StaffDetailsVm>()
                .ForMember(noteVm => noteVm.id_task_staff,
                opt => opt.MapFrom(note => note.id_task_staff))
                .ForMember(noteVm => noteVm.id_task,
                opt => opt.MapFrom(note => note.id_task))
                .ForMember(noteVm => noteVm.id_staff,
                opt => opt.MapFrom(note => note.id_staff));
        }
    }
}
