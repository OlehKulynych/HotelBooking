﻿using HotelBooking.API.Models;
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
        public Task UpdateImageAsync(RoomUpdateImageDto roomUpdateImage);
        Task ReserveRoomAsync(int id, ReservationDto reservationDto);
    }
}
