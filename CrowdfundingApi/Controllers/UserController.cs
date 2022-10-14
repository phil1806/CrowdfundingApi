
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
            _UserService.Create(user);
            return Ok(user);
        }


    }
}
