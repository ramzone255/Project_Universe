using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using Project_Universe.WebApi.src.EntitiesDto.StaffDto;

namespace Project_Universe.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class StaffController : BaseController
    {
        private readonly IMapper _mapper;

        public StaffController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<GetStaffListVm>> GetAllStaffs()
        {
            var query = new GetStaffListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_staff}")]
        public async Task<ActionResult<GetStaffDetailsVm>> GetStaffDetails(int id_staff)
        {
            var query = new GetStaffDetailsQuery
            {
                id_staff = id_staff
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateStaff([FromBody] CreateStaffDto createStaffDto)
        {
            var command = _mapper.Map<CreateStaffCommand>(createStaffDto);
            var id_staff = await Mediator.Send(command);
            return Ok(id_staff);
        }

        [HttpPut("{id_staff}")]
        public async Task<IActionResult> UpdateStaff(int id_staff, [FromBody] UpdateStaffDto updateStaffDto)
        {
            var command = _mapper.Map<UpdateStaffCommand>(updateStaffDto);
            command.id_staff = id_staff;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_staff}")]
        public async Task<IActionResult> DeleteStaff(int id_staff)
        {
            var command = new DeleteStaffCommand
            {
                id_staff = id_staff
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
