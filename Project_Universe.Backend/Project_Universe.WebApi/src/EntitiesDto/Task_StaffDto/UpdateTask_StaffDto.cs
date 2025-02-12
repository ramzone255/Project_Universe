using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Task_Staff.Commands.CreateTask_Staff;
using Project_Universe.Application.src.Entities.Task_Staff.Commands.UpdateTask_Staff;

namespace Project_Universe.WebApi.src.EntitiesDto.Task_StaffDto
{
    public class UpdateTask_StaffDto : IMapWith<UpdateTask_StaffCommand>
    {
        public int? id_task { get; set; }
        public int? id_staff { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTask_StaffDto, UpdateTask_StaffCommand>()
                .ForMember(entityDto => entityDto.id_task,
                opt => opt.MapFrom(entity => entity.id_task))
                .ForMember(entityDto => entityDto.id_staff,
                opt => opt.MapFrom(entity => entity.id_staff));
        }
    }
}
