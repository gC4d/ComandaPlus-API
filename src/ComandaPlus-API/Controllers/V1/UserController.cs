using Asp.Versioning;
using ComandaPlus_API.Application.Dtos;
using ComandaPlus_API.Requests.User;
using ComandaPlus_API.Services;
using EmailService;
using Microsoft.AspNetCore.Mvc;

namespace ComandaPlus_API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateUserInputModel request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);  

            try
            {
                await _userService.CacheUserDataAsync(request);

                await _userService.SendVerificationCodeAsync(request.Email);

                return Ok(new { Message = "Verification code was sent to your email." });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var userDto = new UserDTO();
                if (userDto == null)
                {
                    return NotFound();
                }

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
