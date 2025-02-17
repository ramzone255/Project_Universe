using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Universe.Application.src.Entities.Post.Queries.GetPostList;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;

namespace Project_Universe.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class PostController : BaseController
    {
        private readonly IMapper _mapper;

        public PostController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetPostListVm>> GetAllPosts()
        {
            var query = new GetPostListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
