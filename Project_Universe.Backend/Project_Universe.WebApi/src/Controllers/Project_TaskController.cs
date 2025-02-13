using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Universe.Application.src.Entities.Project_Task.Commands.CreateProject_Task;
using Project_Universe.Application.src.Entities.Project_Task.Commands.DeleteProject_Task;
using Project_Universe.Application.src.Entities.Project_Task.Commands.UpdateProject_Task;
using Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskDetails;
using Project_Universe.Application.src.Entities.Project_Task.Queries.GetProject_TaskList;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using Project_Universe.WebApi.src.EntitiesDto.Project_Task;
using Project_Universe.WebApi.src.EntitiesDto.StaffDto;

namespace Project_Universe.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Project_TaskController : BaseController
    {
        private readonly IMapper _mapper;

        public Project_TaskController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetProject_TaskListVm>> GetAllProject_Tasks()
        {
            var query = new GetProject_TaskListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Details/{id_project_task}")]
        public async Task<ActionResult<GetProject_TaskDetailsVm>> GetProject_TaskDetails(int id_project_task)
        {
            var query = new GetProject_TaskDetailsQuery
            {
                id_project_task = id_project_task
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateProject_Task([FromBody] CreateProject_TaskDto createProject_TaskDto)
        {
            var command = _mapper.Map<CreateProject_TaskCommand>(createProject_TaskDto);
            var id_project_task = await Mediator.Send(command);
            return Ok(id_project_task);
        }

        [HttpPut("Update/{id_project_task}")]
        public async Task<IActionResult> UpdateProject_Task(int id_project_task, [FromBody] UpdateProject_TaskDto updateProject_TaskDto)
        {
            var command = _mapper.Map<UpdateProject_TaskCommand>(updateProject_TaskDto);
            command.id_project_task = id_project_task;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Delete/{id_project_task}")]
        public async Task<IActionResult> DeleteProject_Task(int id_project_task)
        {
            var command = new DeleteProject_TaskCommand
            {
                id_project_task = id_project_task
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
