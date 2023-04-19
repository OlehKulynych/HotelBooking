using HotelBooking.API.Models;

namespace HotelBooking.API.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetRoomsAsync();
        Task<Room> GetRoomByIdAsync(int id);
        Task AddRoomAsync(Room room);
        Task DeleteRoomAsync(int id);
        Task UpdateRoomAsync(Room room);
        Task UpdateImageAsync(int Id, string Image);
    }
}
