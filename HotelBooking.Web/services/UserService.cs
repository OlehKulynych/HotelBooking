using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace HotelBooking.Web.Services
{
    public class UserService: IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDto> GetCurrentUser(string email)
        {
            var response = await _httpClient.GetAsync($"api/user/currentuser/{email}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }

        }
    }
}
