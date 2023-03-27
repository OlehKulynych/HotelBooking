using HotelBooking.Shared.DTO;
using Microsoft.AspNetCore.Identity;

namespace HotelBooking.API.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Register(RegisterUserDto registerUserDto);
        Task<string> LogIn(LogInUserDto userDto);
        Task<UserDto> GetCurrentUserAsync(string email);
    }
}
