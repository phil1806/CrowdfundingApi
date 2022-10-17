using Microsoft.AspNetCore.Mvc;

namespace CrowdfundingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class ContributionsController : Controller
    {   
        private readonly IContributionsService _contributionService
        public 
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetById()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Add()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
