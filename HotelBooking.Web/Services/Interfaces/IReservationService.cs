using HotelBooking.Shared.DTO;

namespace HotelBooking.Web.Services.Interfaces
{
    public interface IReservationService
    {
        Task ReserveRoomAsync(int id, ReservationAddDto reservationDto);
        Task<IEnumerable<ReservationDto>> GetReservationsAsync();
        Task<IEnumerable<ReservationDto>> GetReservationByUserIdAsync(string userId);
        Task CancelReservationAsync(int id);
    }
}
