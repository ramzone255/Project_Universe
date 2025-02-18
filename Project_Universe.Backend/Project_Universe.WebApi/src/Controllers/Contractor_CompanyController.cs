using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Universe.Application.src.Entities.Contractor_Company.Queries.GetContractor_CompanyList;
using Project_Universe.Application.src.Entities.Post.Queries.GetPostList;

namespace Project_Universe.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Contractor_CompanyController : BaseController
    {
        private readonly IMapper _mapper;

        public Contractor_CompanyController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetContractor_CompanyListVm>> GetAllContractor_Companys()
        {
            var query = new GetContractor_CompanyListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
