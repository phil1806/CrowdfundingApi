using BLL.Interfaces;
using BLL.Models;
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



        [HttpPut]
        public IActionResult UpdateProject(int id, Project leProject)
        {
            return Ok(_projetService.UpdateProject(id, leProject));
        }
       
        [HttpDelete]

        public IActionResult DeleteProject(int id)
        {
            return Ok(_projetService.DeleteProject(id));
        }

        [HttpPost("Project")]
        public IActionResult CreateProject(CreateProjectModel pj)
        {

            Console.WriteLine(pj.Titre);

            foreach (var item in pj.Paliers)
            {
                Console.WriteLine(item.Montant);
            }
            return Ok(pj);
        }
    }
}
