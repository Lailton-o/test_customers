using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Domain.Interfaces.Repositories;

namespace Test.Api.Controllers
{
    [ApiController]
    [Route("api/classifications")]
    [Authorize]
    public class ClassificationsController : ControllerBase
    {
        private readonly IClassificationRepository _classificationRepository;

        public ClassificationsController(IClassificationRepository classificationRepository)
        {
            _classificationRepository = classificationRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _classificationRepository.GetAll());
        }
    }
}
