using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatercolorsPainting_Repository.Interface;

namespace PEPRN231_SU24TrialTest_HoVaTen_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        private readonly IStyleRepository styleRepository;

        public StyleController(IStyleRepository styleRepository)
        {
            this.styleRepository = styleRepository;
        }

        [HttpGet]
        public IActionResult GetAsync()
        {
            return Ok(this.styleRepository.GetAll());
        }
    }
}
