using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Universe.Application.src.Entities.Post.Queries.GetPostList;
using Project_Universe.Application.src.Entities.Status.Queries.GetStatusList;

namespace Project_Universe.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class StatusController : BaseController
    {
        private readonly IMapper _mapper;

        public StatusController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetStatusListVm>> GetAllStatuses()
        {
            var query = new GetStatusListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
