using HotelBooking.Shared.DTO;

namespace HotelBooking.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetCurrentUser(string email);
    }
}
