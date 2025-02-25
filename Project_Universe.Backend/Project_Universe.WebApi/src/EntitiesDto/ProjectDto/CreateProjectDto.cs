﻿using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Project.Commands.CreateProject;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.WebApi.src.EntitiesDto.StaffDto;

namespace Project_Universe.WebApi.src.EntitiesDto.ProjectDto
{
    public class CreateProjectDto : IMapWith<CreateProjectCommand>
    {
        public string name_project { get; set; }
        public DateTime start_date_project { get; set; }
        public DateTime? end_date_project { get; set; }
        public int id_contractor_company { get; set; }
        public int id_customer_company { get; set; }
        public int id_priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
                .ForMember(entityDto => entityDto.name_project,
                opt => opt.MapFrom(entity => entity.name_project))
                .ForMember(entityDto => entityDto.start_date_project,
                opt => opt.MapFrom(entity => entity.start_date_project))
                .ForMember(entityDto => entityDto.end_date_project,
                opt => opt.MapFrom(entity => entity.end_date_project))
                .ForMember(entityDto => entityDto.id_contractor_company,
                opt => opt.MapFrom(entity => entity.id_contractor_company))
                .ForMember(entityDto => entityDto.id_customer_company,
                opt => opt.MapFrom(entity => entity.id_customer_company))
                .ForMember(entityDto => entityDto.id_priority,
                opt => opt.MapFrom(entity => entity.id_priority));
        }
    }
}
