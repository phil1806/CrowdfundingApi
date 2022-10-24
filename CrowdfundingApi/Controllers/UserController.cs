
using BLL.Interfaces;
using BLL.Models;
using CrowdfundingApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserAPI = CrowdfundingApi.Models.UserAPI;

namespace CrowdfundingApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller {

        private readonly IUserService _UserService;
        private readonly TokenManager _tokenManager;

        public UserController(IUserService userService, TokenManager tokenManager) {
            _UserService = userService;
            _tokenManager = tokenManager;
        }

        [HttpPost("Register")]
        public IActionResult Register(UserForm user) {
            try {//TODO same code in login and register => to methode API.User login( BLL.User )
                User u = _UserService.Create(user);
                UserAPI cu = new UserAPI {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    Token = _tokenManager.GenerateToken(u),
                    Email = u.Email
                };
                return Ok(cu);
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLogin user) {
            try {
                User u = _UserService.Login(user);
                UserAPI cu = new UserAPI {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    Token = _tokenManager.GenerateToken(u),
                    Email = u.Email
                };
                return Ok(cu);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        public IActionResult Update(User user) {
            try {
                _UserService.Update(user);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
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
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll() {

            return Ok(_UserService.GetAllUsers());
        }


    }
}
