using HotelBooking.API.Models;
using HotelBooking.Shared.DTO;

namespace HotelBooking.API.Interfaces
{
    public interface IReservationService
    {
        Task ReserveRoomAsync(int id, ReservationAddDto reservation);

        Task CancelReservationAsync(int id);


        Task<IEnumerable<ReservationDto>> GetReservationsAsync();

        Task<IEnumerable<ReservationDto>> GetReservationsByUserIdAsync(string userId);
    }
}
