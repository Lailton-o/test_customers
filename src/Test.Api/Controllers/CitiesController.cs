using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interfaces.Repositories;

namespace Test.Api.Controllers
{
    [ApiController]
    [Route("api/cities")]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CitiesController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllByRegion(int regionId)
        {
            return Ok(await _cityRepository.GetAllByRegion(new Region(regionId)));
        }
    }
}
