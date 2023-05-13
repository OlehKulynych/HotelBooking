using HotelBooking.API.Models;

namespace HotelBooking.API.Interfaces
{
    public interface IReservationRepository
    {
        Task ReserveRoomAsync(Reservation reservation);
       
        Task CancelReservationAsync(int id);
   

        Task<IEnumerable<Reservation>> GetReservationsAsync();
      
        Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(string userId);
    


    
}
}
