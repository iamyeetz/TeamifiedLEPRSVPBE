using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeamifiedLEPRSVPBE.Application.Dtos;


namespace TeamifiedLEPRSVPBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            //just a fake authentication for demonstration purposes
            //but was supposed to be replaced with a real authentication logic using JWT token
            //having only username claim
            return Ok(loginDto.username);
        }
    }
}
