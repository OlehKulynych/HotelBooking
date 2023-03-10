using HotelBooking.API.Models;

namespace HotelBooking.API.Interfaces
{
    public interface IRoomTypeRepository
    {

        Task<RoomType> GetRoomTypeByIdAsync(int id);
        Task<IEnumerable<RoomType>> GetRoomTypesAsync();
        Task AddRoomTypeAsync(RoomType roomType);
        Task DeleteRoomTypeAsync(int id);
        Task UpdateRoomTypeAsync(RoomType roomType);
    }
}
