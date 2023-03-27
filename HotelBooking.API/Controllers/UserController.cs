using HotelBooking.API.Interfaces;
using HotelBooking.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
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


        [Route("Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto user)
        {

            var identityResult = await _userService.Register(user);

            if (identityResult.Succeeded == true)
            {
                return Ok(new { identityResult.Succeeded });
            }
            else
            {
                string errorMessage = "Error register: ";
                foreach (var errors in identityResult.Errors)
                {
                    errorMessage += Environment.NewLine;
                    errorMessage += $"{errors.Description}";

                }
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }

        [Route("SignIn")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LogInUserDto userDto)
        {

            var tokenResult = await _userService.LogIn(userDto);
            if (tokenResult != null)
            {

                return Ok(tokenResult);

            }
            else
            {
                return Unauthorized(userDto);
            }
        }

        [Route("CurrentUser/{email}")]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUserByEmailAsync(string email)
        {
            var user = await _userService.GetCurrentUserAsync(email);
            return Ok(user);
        }
    }
}
