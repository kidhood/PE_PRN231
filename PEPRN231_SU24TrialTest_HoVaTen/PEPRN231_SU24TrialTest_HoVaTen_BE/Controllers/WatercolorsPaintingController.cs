using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WatercolorsPainting_BO;
using WatercolorsPainting_Repository.Interface;

namespace PEPRN231_SU24TrialTest_HoVaTen_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatercolorsPaintingController : ControllerBase
    {
        private readonly IWatercolorsPaintingRepository watercolorsPaintingRepository;

        public WatercolorsPaintingController(IWatercolorsPaintingRepository watercolorsPaintingRepository)
        {
            this.watercolorsPaintingRepository = watercolorsPaintingRepository;
        }

        [Authorize(Roles = "2, 3")]
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(this.watercolorsPaintingRepository.GetAll());
        }

        [Authorize(Roles = "3")]
        [HttpPost]
        public IActionResult Create([FromBody] WatercolorsPainting watercolorsPainting)
        {
            if(watercolorsPainting != null)
            {
                this.watercolorsPaintingRepository.CreateWater(watercolorsPainting);
                return Ok("Create success full");
            }

            return BadRequest("Create fail");
        }

        [Authorize(Roles = "3")]
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] WatercolorsPainting watercolorsPainting, string id)
        {
            if (watercolorsPainting != null)
            {
                this.watercolorsPaintingRepository.UpdateWater(watercolorsPainting);
                return Ok("Update successfull");
            }

            return BadRequest("Update fail");
        }
    }
}
