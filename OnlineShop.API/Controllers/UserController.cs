using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Abstractions.Operations;
using OnlineShop.Core.BusinessModels;
using System.Threading.Tasks;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISignInSystemOperation _signInSystemOperation;
        public UserController(ISignInSystemOperation signInSystemOperation)
        {
            _signInSystemOperation = signInSystemOperation;
        }
        [Authorize(Roles = "User" /*"User" = 0; OR "Admin" = 1*/)]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _signInSystemOperation.GetAll();
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetId([FromRoute] int id)
        {
            var result = _signInSystemOperation.Get(id);
            return Ok(result);
        }        
        //
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                await _signInSystemOperation.Login(model, HttpContext);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                await _signInSystemOperation.Register(model, HttpContext);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInSystemOperation.Logout(HttpContext);
            return Ok();
        }
    }
}
