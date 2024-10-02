using ComandaPlus_Core.Dtos;
using ComandaPlus_Core.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ComandaPlus_API.Controllers;


[Route("api/v1/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        return Ok();
    }
}
