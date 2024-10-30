using ComandaPlus_API.Dtos;
using ComandaPlus_API.Requests.User;
using ComandaPlus_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComandaPlus_API.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);  

            try
            {
                var userDto = await _userService.Create(request);
                if (userDto == null)
                    return StatusCode(500, "An error occurred while creating the user.");

                return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
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
