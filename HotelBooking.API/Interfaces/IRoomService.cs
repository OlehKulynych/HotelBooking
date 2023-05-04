using HotelBooking.API.Models;
using HotelBooking.Shared.DTO;

namespace HotelBooking.API.Interfaces
{
    public interface IRoomService
    {
        public Task<IEnumerable<RoomDto>> GetRoomsAsync();
        public Task<RoomDto> GetRoomByIdAsync(int id);
        public Task<IEnumerable<RoomDto>> GetRoomByTypeIdAsync(int id);
        public Task AddRoomAsync(RoomAddDto roomAddDto);
        public Task DeleteRoomAsync(int id);
        public Task UpdateRoomAsync(RoomDto roomDto);
        public Task UpdateImageAsync(RoomUpdateImageDto roomUpdateImage);
        Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync(FilterRoomDto filterRoomDto);
    }
}
