using BLL.Interfaces;
using BLL.Models;
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

        [HttpGet("projetId/{id}")]
        public IActionResult GetPalierByProjetId(int id)
        {
            try
            {
                return Ok(_palierService.GetPalierByProjetId(id));

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

        [HttpPut]

        public IActionResult UpdatePalier(Paliers P)
        {
            return Ok(_palierService.UpdatePalier( P));
        }

        [HttpPost]
        public IActionResult CreatePalier(Paliers P)
        {
            return Ok(_palierService.CreatePalier(P));
        }
    }
}
