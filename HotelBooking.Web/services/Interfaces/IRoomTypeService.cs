using HotelBooking.Shared.DTO;

namespace HotelBooking.Web.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeDto>> GetRoomTypesAsync();
        Task<RoomTypeDto> GetRoomTypeByIdAsync(int id);
        Task UpdateRoomTypeAsync(RoomTypeDto roomTypeAddDto);
        Task AddBookCategoryAsync(RoomTypeAddDto roomTypeAddDto);
        Task DeleteBookCategoryAsync(int id);
    }
}
