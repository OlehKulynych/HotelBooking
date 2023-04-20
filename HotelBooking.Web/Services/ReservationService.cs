using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace HotelBooking.Web.Services
{
    public class ReservationService : IReservationService
    {

        private readonly HttpClient _httpClient;
        public ReservationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CancelReservationAsync(int id)
        {

            await _httpClient.DeleteAsync($"api/Reservation/CancelReservation/{id}");
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationByUserIdAsync(string userId)
        {

            var response = await _httpClient.GetAsync($"api/Reservation/UserReservation/{userId}");

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<ReservationDto>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<ReservationDto>>();
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsAsync()
        {

            var response = await _httpClient.GetAsync("api/Reservation");

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<ReservationDto>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<ReservationDto>>();
        }

        public async Task ReserveRoomAsync(int id, ReservationAddDto reservationDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Reservation/Reserve/{id}", reservationDto);

        }
    }
}
