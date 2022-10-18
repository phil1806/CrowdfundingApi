using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdfundingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projetService;

        //CONSTRUCTEUR
        public ProjectController(IProjectService projectService)
        {
            _projetService = projectService;
        }


        //lISTE DES METHODES
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            return Ok(_projetService.GetAllProjects());
        }

        [HttpGet("ProjectValider")]
        public IActionResult GetValidProjects()
        {
            return Ok(_projetService.GetValidProjects());
        }

        [HttpPut("ValidProjet")]

        public IActionResult ValidProject(int id)
        {
      
            return Ok(_projetService.ValidProject(id));
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            try
            {
                return Ok(_projetService.GetProjectById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
