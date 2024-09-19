using Microsoft.AspNetCore.Mvc;

namespace ComandaPlus_API.Controllers;


[Route("api/v1/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiController]
public class AccountController : ControllerBase
{
  [HttpPost("/create")]
  public async Task<IActionResult>([FromBody]   
}
