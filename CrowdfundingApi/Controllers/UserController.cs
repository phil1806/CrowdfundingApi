
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrowdfundingApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller {

        private readonly IUserService _UserService;

        public UserController(IUserService userService) {
            _UserService = userService;
        }

        [HttpPost("Register")]
        public IActionResult Register(UserForm user) {
            try {
                return Ok(_UserService.Create(user));
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost("Login")]
        public IActionResult Login(UserLogin user) {
            try {
                return Ok(_UserService.Login(user));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        public IActionResult Update(User user) {
            try {
                return Ok(_UserService.Update(user));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Remove(int id) {
            _UserService.Delete(id);
            return Ok();
        }

        [HttpGet( "{id}" ) ]
        public IActionResult GetUserById(int id) {
            try {

                return Ok(_UserService.GetUserById(id)) ;
            }catch(Exception ex) {
                return NotFound(ex);
            }
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_UserService.GetAllUsers());
        }


    }
}
