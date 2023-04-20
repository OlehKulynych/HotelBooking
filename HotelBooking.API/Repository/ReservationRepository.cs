using HotelBooking.API.Interfaces;
using HotelBooking.API.Models;
using HotelBooking.API.Repository.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.API.Repository
{
    public class ReservationRepository: IReservationRepository
    {
        private readonly HotelBookingDataBaseContext _dataBaseContext;

        public ReservationRepository(HotelBookingDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task ReserveRoomAsync(int id, Reservation reservation)
        {

            var room = await _dataBaseContext.Rooms.FindAsync(id);
            if (room != null)
            {
                var overlappingReservations = await _dataBaseContext.Reservations
            .Where(r => r.RoomId == id &&
                        r.StartDate < reservation.EndDate &&
                        r.EndDate > reservation.StartDate).ToListAsync();

                if (overlappingReservations.Count > 0)
                {
                    throw new Exception();
                }
                reservation.RoomId = id;
                reservation.StatusReservation = StatusReservation.Created;
                _dataBaseContext.Reservations.Add(reservation);
                await _dataBaseContext.SaveChangesAsync();
            }
        }

        public async Task CancelReservationAsync(int id)
        {
            var reservation = await _dataBaseContext.Reservations.FindAsync(id);

            if(reservation != null)
            {
                reservation.StatusReservation = StatusReservation.Cancel;
                _dataBaseContext.Reservations.Update(reservation);
                await _dataBaseContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            var reservations = await _dataBaseContext.Reservations.Include(u => u.User).ToListAsync();
            return reservations;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(string userId)
        {
            var reservations = await _dataBaseContext.Reservations.Include(u => u.User).Where(u => u.UserId == userId).ToListAsync();
            return reservations;
        }


    }
}
