using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Project_Task.Commands.CreateProject_Task;
using Project_Universe.Application.src.Entities.Project_Task.Commands.UpdateProject_Task;

namespace Project_Universe.WebApi.src.EntitiesDto.Project_Task
{
    public class UpdateProject_TaskDto : IMapWith<UpdateProject_TaskCommand>
    {
        public int? id_task { get; set; }
        public int? id_project { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProject_TaskDto, UpdateProject_TaskCommand>()
                .ForMember(entityDto => entityDto.id_task,
                opt => opt.MapFrom(entity => entity.id_task))
                .ForMember(entityDto => entityDto.id_project,
                opt => opt.MapFrom(entity => entity.id_project));
        }
    }
}
