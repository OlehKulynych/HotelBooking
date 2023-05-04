using HotelBooking.Shared.DTO;

namespace HotelBooking.Web.Services.Interfaces
{
    public interface IRoomService
    {

        Task<IEnumerable<RoomDto>> GetRoomsAsync();
        Task<RoomDto> GetRoomById(int id);
        Task AddRoomAsync(RoomAddDto roomAddDto);
        Task<IEnumerable<RoomDto>> GetRoomByTypeIdAsync(int id);
        Task DeleteRoomAsync(int id);
        Task UpdateBookAsync(RoomDto roomDto);
        Task UpdateImageAsync(RoomUpdateImageDto roomUpdateImageDto);
        Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync(FilterRoomDto filter);
    }
}
