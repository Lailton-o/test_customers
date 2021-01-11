using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Domain.Interfaces.Repositories;

namespace Test.Api.Controllers
{
    [ApiController]
    [Route("api/regions")]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _regionRepository.GetAll());
        }
    }
}
