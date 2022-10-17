
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

        [HttpPost]
        public IActionResult Register(UserForm user) {
            try {
                return Ok(_UserService.Create(user));
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }


    }
}
