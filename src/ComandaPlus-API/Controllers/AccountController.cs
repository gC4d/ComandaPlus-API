using ComandaPlus_Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ComandaPlus_API.Controllers;


[Route("api/v1/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiController]
public class AccountController : ControllerBase
{
    
    [HttpPost("/create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] AccountDTO account){
        return Ok();
    }
}
