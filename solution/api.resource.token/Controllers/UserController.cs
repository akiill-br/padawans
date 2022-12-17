using ApiResource.Application.DTOs;
using ApiResource.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.resource.token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> PostAsync([FromForm] UserDTO userDTO)
        {
            var result = await _userService.GenerateTokenAsync(userDTO);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult> Refresh([FromForm] string token, [FromForm] string refreshToken)
        {
            var result = await _userService.RefreshToken(token, refreshToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

    }
}
