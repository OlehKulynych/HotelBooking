using HotelBooking.API.Interfaces;
using HotelBooking.API.Models;
using HotelBooking.API.Repository.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.API.Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HotelBookingDataBaseContext _dataBaseContext;
        public RoomTypeRepository(HotelBookingDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task AddRoomTypeAsync(RoomType roomType)
        {

            _dataBaseContext.RoomTypes.Add(roomType);
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task DeleteRoomTypeAsync(int id)
        {
            var rt = await GetRoomTypeByIdAsync(id);
            _dataBaseContext.RoomTypes.Remove(rt);
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task<RoomType> GetRoomTypeByIdAsync(int id)
        {
            return await _dataBaseContext.RoomTypes.Where(rt => rt.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RoomType>> GetRoomTypesAsync()
        {
            return await _dataBaseContext.RoomTypes.ToListAsync();
        }

        public async Task UpdateRoomTypeAsync(RoomType roomType)
        {
            _dataBaseContext.RoomTypes.Update(roomType);
            await _dataBaseContext.SaveChangesAsync();
        }
    }
}
