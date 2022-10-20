using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdfundingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalierController : ControllerBase
    {

        private readonly IPalierService _palierService;

        public PalierController(IPalierService palierService)
        {
            _palierService = palierService;
        }

        [HttpGet]
        public IActionResult GetAllPalier()
        {
            return Ok(_palierService.GetAllPaliers());
        }

        [HttpGet("{id}")]
        public IActionResult GetPalierById(int id)
        {
            try
            {
                return Ok(_palierService.GetPalierById(id));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeletePalier(int id)
        {
            return Ok(_palierService.DeletePalier(id));
        }
    }
}
