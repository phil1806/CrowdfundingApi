using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrowdfundingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class ContributionsController : Controller
    {
        private readonly IContributionService _contributionService;
        public ContributionsController(IContributionService contributionService)
        {
            _contributionService = contributionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_contributionService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_contributionService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Add(ContributionForm contribution)
        {
            try
            {
                return Ok(_contributionService.Add(contribution));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
