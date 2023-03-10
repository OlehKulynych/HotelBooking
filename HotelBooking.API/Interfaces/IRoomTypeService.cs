using HotelBooking.Shared.DTO;

namespace HotelBooking.API.Interfaces
{
    public interface IRoomTypeService
    {
        public Task<IEnumerable<RoomTypeDto>> GetRoomTypesAsync();

        public Task AddRoomTypeAsync(RoomTypeAddDto roomTypeAddDto);
        public Task<RoomTypeDto> GetRoomTypeByIdAsync(int id);

        public Task UpdateRoomTypeAsync(RoomTypeDto roomTypeDto);
        public Task DeleteRoomTypeAsync(int id);

    }
}
