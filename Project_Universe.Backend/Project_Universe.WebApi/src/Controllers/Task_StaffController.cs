using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using Project_Universe.Application.src.Entities.Task_Staff.Commands.CreateTask_Staff;
using Project_Universe.Application.src.Entities.Task_Staff.Commands.DeleteTask_Staff;
using Project_Universe.Application.src.Entities.Task_Staff.Commands.UpdateTask_Staff;
using Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffDetails;
using Project_Universe.Application.src.Entities.Task_Staff.Queries.GetTask_StaffList;
using Project_Universe.WebApi.src.EntitiesDto.StaffDto;
using Project_Universe.WebApi.src.EntitiesDto.Task_StaffDto;

namespace Project_Universe.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Task_StaffController : BaseController
    {
        private readonly IMapper _mapper;

        public Task_StaffController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<GetTask_StaffListVm>> GetAllTask_Staffs()
        {
            var query = new GetTask_StaffListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_task_staff}")]
        public async Task<ActionResult<GetTask_StaffDetailsVm>> GetTask_StaffDetails(int id_task_staff)
        {
            var query = new GetTask_StaffDetailsQuery
            {
                id_task_staff = id_task_staff
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTask_Staff([FromBody] CreateTask_StaffDto createTask_StaffDto)
        {
            var command = _mapper.Map<CreateTask_StaffCommand>(createTask_StaffDto);
            var id_task_staff = await Mediator.Send(command);
            return Ok(id_task_staff);
        }

        [HttpPut("{id_task_staff}")]
        public async Task<IActionResult> UpdateTask_Staff(int id_task_staff, [FromBody] UpdateTask_StaffDto updateTask_StaffDto)
        {
            var command = _mapper.Map<UpdateTask_StaffCommand>(updateTask_StaffDto);
            command.id_task_staff = id_task_staff;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_task_staff}")]
        public async Task<IActionResult> DeleteTask_Staff(int id_task_staff)
        {
            var command = new DeleteTask_StaffCommand
            {
                id_task_staff = id_task_staff
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
