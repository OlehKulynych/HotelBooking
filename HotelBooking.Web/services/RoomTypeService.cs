using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace HotelBooking.Web.Services
{
    public class RoomTypeService : IRoomTypeService
    {

        private readonly HttpClient _httpClient;

        public RoomTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBookCategoryAsync(RoomTypeAddDto roomTypeAddDto)
        {

            await _httpClient.PostAsJsonAsync("api/RoomType/AddRoomType", roomTypeAddDto);
        }

        public async Task DeleteBookCategoryAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/RoomType/DeleteRoomType/{id}");
        }

        public async Task<RoomTypeDto> GetRoomTypeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/RoomType/RoomTypeById/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(RoomTypeDto);
            }
            return await response.Content.ReadFromJsonAsync<RoomTypeDto>();
        }

        public async Task<IEnumerable<RoomTypeDto>> GetRoomTypesAsync()
        {

            var response = await _httpClient.GetAsync("api/RoomType");

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<RoomTypeDto>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<RoomTypeDto>>();
        }

        public async Task UpdateRoomTypeAsync(RoomTypeDto roomTypeAddDto)
        {

            await _httpClient.PutAsJsonAsync("api/RoomType/UpdateRoomType", roomTypeAddDto);
        }
    }
}
