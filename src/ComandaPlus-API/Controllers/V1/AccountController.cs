using Asp.Versioning;
using ComandaPlus_API.Dtos;
using ComandaPlus_API.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ComandaPlus_API.Controllers.V1;


[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiExplorerSettings(GroupName = "v1")]
[ApiVersion("1.0")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("/add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] AccountDTO accountDTO){
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        await _accountService.Add(accountDTO);

        return Ok(accountDTO);
    }
}
