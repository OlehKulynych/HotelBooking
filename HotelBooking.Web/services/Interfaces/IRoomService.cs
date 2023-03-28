using HotelBooking.Shared.DTO;

namespace HotelBooking.Web.Services.Interfaces
{
    public interface IRoomService
    {

        Task<IEnumerable<RoomDto>> GetRoomsAsync();
        Task<RoomDto> GetRoomById(int id);
        Task AddRoomAsync(RoomAddDto roomAddDto);

        Task DeleteRoomAsync(int id);
        Task UpdateBookAsync(RoomDto roomDto);
    }
}
