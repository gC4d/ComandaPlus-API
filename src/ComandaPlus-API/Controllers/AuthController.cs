using ComandaPlus_Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ComandaPlus_API.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("/add-user")]
        public IActionResult register([FromBody] RegisterDto view)
        {
            return Ok();
        }
        
        [HttpPost("/auth-user")]
        public IActionResult auth(){
            return Ok();
        }
    }
}
