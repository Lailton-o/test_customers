using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Domain.Interfaces.Repositories;
using Test.Domain.Interfaces.Services;
using Test.Shared.DTOs;

namespace Test.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUserRepository _userRepository;

        public CustomersController(ICustomerService customerService, IUserRepository userRepository)
        {
            _customerService = customerService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Search([FromQuery] FilterCustomer filter)
        {
            var login = HttpContext.User.Identity.Name;
            if(string.IsNullOrEmpty(login))
                return BadRequest("User not authenticated!");

            var user = _userRepository.GetUserRoleByLogin(login);
            if (user.Result.UserRole.IsAdmin)
            {
                return Ok(await _customerService.GetCustomersAdminBy(filter));
            }
            else
            {
                return Ok(await _customerService.GetCustomersSellersBy(filter));
            }
        }
    }
}
