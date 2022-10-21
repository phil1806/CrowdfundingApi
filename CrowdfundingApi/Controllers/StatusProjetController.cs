using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrowdfundingApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StatusProjetController : Controller {

        private IStatusProjetService statuService;


        public StatusProjetController(IStatusProjetService _statuService) {
            statuService = _statuService;
        }

        [HttpPost]
        public ActionResult Create(StatusBll s) {
            statuService.Create(s);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll() {
            return Ok(statuService.GetAll());
        }

        [HttpPut]
        public ActionResult Update(StatusBll s) {
            try {
                statuService.Update(s);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id) {
            try {
                statuService.Delete(id);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}
