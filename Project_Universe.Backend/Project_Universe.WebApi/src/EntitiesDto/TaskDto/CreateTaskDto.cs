using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Entities.Task_Entity.Commands.CreateTask;
using Project_Universe.WebApi.src.EntitiesDto.StaffDto;

namespace Project_Universe.WebApi.src.EntitiesDto.TaskDto
{
    public class CreateTaskDto : IMapWith<CreateTaskCommand>
    {
        public string name_task { get; set; }
        public string comment { get; set; }
        public int id_status { get; set; }
        public int id_priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                .ForMember(entityDto => entityDto.name_task,
                opt => opt.MapFrom(entity => entity.name_task))
                .ForMember(entityDto => entityDto.comment,
                opt => opt.MapFrom(entity => entity.comment))
                .ForMember(entityDto => entityDto.id_status,
                opt => opt.MapFrom(entity => entity.id_status))
                .ForMember(entityDto => entityDto.id_priority,
                opt => opt.MapFrom(entity => entity.id_priority));
        }
    }
}
