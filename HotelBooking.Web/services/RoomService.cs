using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace HotelBooking.Web.Services
{
    public class RoomService : IRoomService
    {

        private readonly HttpClient _httpClient;
        public RoomService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddRoomAsync(RoomAddDto roomAddDto)
        {

            await _httpClient.PostAsJsonAsync("api/Room/AddRoom", roomAddDto);
        }

        public async Task DeleteRoomAsync(int id)
        {

            await _httpClient.DeleteAsync($"api/Room/DeleteRoom/{id}");
        }

        public async Task<RoomDto> GetRoomById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Room/{id}");


            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(RoomDto);
            }
            return await response.Content.ReadFromJsonAsync<RoomDto>();

        }
        public async Task<IEnumerable<RoomDto>> GetRoomsAsync()
        {
            var response = await _httpClient.GetAsync("api/Room");

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<RoomDto>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<RoomDto>>();


        }

        public async Task UpdateBookAsync(RoomDto roomDto)
        {
            await _httpClient.PutAsJsonAsync("api/Room/UpdateRoom", roomDto);
        }

        public async Task UpdateImageAsync(RoomUpdateImageDto roomUpdateImageDto)
        {
            await _httpClient.PutAsJsonAsync("api/Room/UpdateImage", roomUpdateImageDto);
        }
    }
}
