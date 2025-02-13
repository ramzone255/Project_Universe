using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using Project_Universe.Application.src.Entities.Task_Entity.Commands.CreateTask;
using Project_Universe.Application.src.Entities.Task_Entity.Commands.DeleteTask;
using Project_Universe.Application.src.Entities.Task_Entity.Commands.UpdateTask;
using Project_Universe.Application.src.Entities.Task_Entity.Queries.GetTaskDetails;
using Project_Universe.Application.src.Entities.Task_Entity.Queries.GetTaskList;
using Project_Universe.WebApi.src.EntitiesDto.StaffDto;
using Project_Universe.WebApi.src.EntitiesDto.TaskDto;

namespace Project_Universe.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : BaseController
    {
        private readonly IMapper _mapper;

        public TaskController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetTaskListVm>> GetAllTasks()
        {
            var query = new GetTaskListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Details/{id_task}")]
        public async Task<ActionResult<GetTaskDetailsVm>> GetTaskDetails(int id_task)
        {
            var query = new GetTaskDetailsQuery
            {
                id_task = id_task
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
            var id_task = await Mediator.Send(command);
            return Ok(id_task);
        }

        [HttpPut("Update/{id_task}")]
        public async Task<IActionResult> UpdateTask(int id_task, [FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
            command.id_task = id_task;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Delete/{id_task}")]
        public async Task<IActionResult> DeleteTask(int id_task)
        {
            var command = new DeleteTaskCommand
            {
                id_task = id_task
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
