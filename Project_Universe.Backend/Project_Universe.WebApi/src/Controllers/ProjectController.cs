using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Universe.Application.src.Entities.Project.Commands.CreateProject;
using Project_Universe.Application.src.Entities.Project.Commands.DeleteProject;
using Project_Universe.Application.src.Entities.Project.Commands.UpdateProject;
using Project_Universe.Application.src.Entities.Project.Queries.GetProjectDetails;
using Project_Universe.Application.src.Entities.Project.Queries.GetProjectList;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.DeleteStaff;
using Project_Universe.Application.src.Entities.Staff.Commands.UpdateStaff;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffDetails;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using Project_Universe.WebApi.src.EntitiesDto.ProjectDto;
using Project_Universe.WebApi.src.EntitiesDto.StaffDto;

namespace Project_Universe.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : BaseController
    {
        private readonly IMapper _mapper;

        public ProjectController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<GetProjectListVm>> GetAllProject()
        {
            var query = new GetProjectListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_project}")]
        public async Task<ActionResult<GetProjectDetailsVm>> GetProjectDetails(int id_project)
        {
            var query = new GetProjectDetailsQuery
            {
                id_project = id_project
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProject([FromBody] CreateProjectDto createProjectDto)
        {
            var command = _mapper.Map<CreateProjectCommand>(createProjectDto);
            var id_project = await Mediator.Send(command);
            return Ok(id_project);
        }

        [HttpPut("{id_project}")]
        public async Task<IActionResult> UpdateProject(int id_project, [FromBody] UpdateProjectDto updateProjectDto)
        {
            var command = _mapper.Map<UpdateProjectCommand>(updateProjectDto);
            command.id_project = id_project;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_project}")]
        public async Task<IActionResult> DeleteProject(int id_project)
        {
            var command = new DeleteProjectCommand
            {
                id_project = id_project
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
