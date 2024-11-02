using Microsoft.AspNetCore.Mvc;
using ComandaPlus_API.Interfaces.Services;
using Asp.Versioning;

namespace ComandaPlus_API.Controllers.V1
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ILicenseService licenseService; 
    }
}
