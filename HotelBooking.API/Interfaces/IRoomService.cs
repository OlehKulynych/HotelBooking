using HotelBooking.Shared.DTO;

namespace HotelBooking.API.Interfaces
{
    public interface IRoomService
    {
        public Task<IEnumerable<RoomDto>> GetRoomsAsync();
        public Task<RoomDto> GetRoomByIdAsync(int id);
        public Task AddRoomAsync(RoomAddDto roomAddDto);
        public Task DeleteRoomAsync(int id);
        public Task UpdateRoomAsync(RoomDto roomDto);

    }
}
