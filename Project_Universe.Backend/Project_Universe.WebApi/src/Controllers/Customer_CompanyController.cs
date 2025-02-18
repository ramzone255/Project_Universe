using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Universe.Application.src.Entities.Customer_Company.Queries.GetCustomer_CompanyList;
using Project_Universe.Application.src.Entities.Post.Queries.GetPostList;

namespace Project_Universe.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Customer_CompanyController : BaseController
    {
        private readonly IMapper _mapper;

        public Customer_CompanyController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetCustomer_CompanyListVm>> GetAllCustomer_Company()
        {
            var query = new GetCustomer_CompanyListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
