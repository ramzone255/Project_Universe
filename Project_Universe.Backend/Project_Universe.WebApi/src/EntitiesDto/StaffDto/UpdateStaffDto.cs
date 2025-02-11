using AutoMapper;
using Project_Universe.Application.src.Common.Mapping;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;

namespace Project_Universe.WebApi.src.EntitiesDto.StaffDto
{
    public class UpdateStaffDto : IMapWith<UpdateStaffCommand>
    {
        public string name_staff { get; set; }
        public string lastname_staff { get; set; }
        public string patronymic_staff { get; set; }
        public string email_staff { get; set; }
        public int id_post { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateStaffDto, UpdateStaffCommand>()
                .ForMember(entityDto => entityDto.name_staff,
                opt => opt.MapFrom(entity => entity.name_staff))
                .ForMember(entityDto => entityDto.lastname_staff,
                opt => opt.MapFrom(entity => entity.lastname_staff))
                .ForMember(entityDto => entityDto.patronymic_staff,
                opt => opt.MapFrom(entity => entity.patronymic_staff))
                .ForMember(entityDto => entityDto.email_staff,
                opt => opt.MapFrom(entity => entity.email_staff))
                .ForMember(entityDto => entityDto.id_post,
                opt => opt.MapFrom(entity => entity.id_post));
        }
    }
}
