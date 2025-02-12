using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Entities.Task_Staff.Commands.CreateTask_Staff;
using Project_Universe.WebApi.src.EntitiesDto.StaffDto;

namespace Project_Universe.WebApi.src.EntitiesDto.Task_StaffDto
{
    public class CreateTask_StaffDto : IMapWith<CreateTask_StaffCommand>
    {
        public int? id_task { get; set; }
        public int? id_staff { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTask_StaffDto, CreateTask_StaffCommand>()
                .ForMember(entityDto => entityDto.id_task,
                opt => opt.MapFrom(entity => entity.id_task))
                .ForMember(entityDto => entityDto.id_staff,
                opt => opt.MapFrom(entity => entity.id_staff));
        }
    }
}
