using HotelBooking.API.Models;
using HotelBooking.Shared.DTO;

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

        Task<IEnumerable<Room>> GetRoomByTypeIdAsync(int id);
    }
}
