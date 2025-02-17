using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Universe.Application.src.Entities.Post.Queries.GetPostList;
using Project_Universe.Application.src.Entities.Priority.Queries.GetPriorityList;

namespace Project_Universe.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class PriorityController : BaseController
    {
        private readonly IMapper _mapper;

        public PriorityController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetPriorityListVm>> GetAllPrioritys()
        {
            var query = new GetPriorityListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
