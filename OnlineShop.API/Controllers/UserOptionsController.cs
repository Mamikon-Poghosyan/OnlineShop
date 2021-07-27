using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Abstractions.Operations;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserOptionsController : ControllerBase
    {
        private readonly IUserOperation _userOperation;
        public UserOptionsController(IUserOperation userOperation)
        {
            _userOperation = userOperation;
        }
        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            var result = _userOperation.GetUser(id);
            return Ok(result);
        }
    }
}
