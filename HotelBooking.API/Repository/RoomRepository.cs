using HotelBooking.API.Interfaces;
using HotelBooking.API.Models;
using HotelBooking.API.Repository.DataBaseContext;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace HotelBooking.API.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelBookingDataBaseContext _dataBaseContext;
        public RoomRepository(HotelBookingDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task AddRoomAsync(Room room)
        {
            _dataBaseContext.Rooms.Add(room);
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int id)
        {
            var room = await _dataBaseContext.Rooms.Include(t => t.RoomType).Where(i => i.Id == id).FirstOrDefaultAsync();
            if (room != null)
            {
                room.isAvailable = true;
                await _dataBaseContext.SaveChangesAsync();
            }
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _dataBaseContext.Rooms.Include(t => t.RoomType).Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await _dataBaseContext.Rooms.Include(t => t.RoomType).ToListAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _dataBaseContext.Update(room);
            await _dataBaseContext.SaveChangesAsync();
        }
        public async Task UpdateImageAsync(int Id, string Image)
        {
            var book = await _dataBaseContext.Rooms.Where(i => i.Id == Id).FirstOrDefaultAsync();
            book.ImageString = Image;
            await _dataBaseContext.SaveChangesAsync();
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

                if(overlappingReservations.Count > 0)
                {
                    throw new Exception();
                }
                reservation.RoomId = id;
                reservation.StatusReservation = StatusReservation.Created;
                _dataBaseContext.Reservations.Add(reservation);
                await _dataBaseContext.SaveChangesAsync();
            }
        }
    }
}
