using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Domain.Interfaces.Repositories;

namespace Test.Api.Controllers
{
    [ApiController]
    [Route("api/sellers")]
    [Authorize]
    public class SellersControllers : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public SellersControllers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _userRepository.GetAllSellers());
        }
    }
}
