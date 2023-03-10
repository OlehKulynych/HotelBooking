using AutoMapper;
using HotelBooking.API.Interfaces;
using HotelBooking.API.Models;
using HotelBooking.Shared.DTO;

namespace HotelBooking.API.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly IRoomTypeRepository _roomTypeRepository;
        public RoomService(IRoomRepository roomRepository, IMapper mapper, IRoomTypeRepository roomTypeRepository)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task AddRoomAsync(RoomAddDto roomAddDto)
        {
            await _roomRepository.AddRoomAsync(_mapper.Map<Room>(roomAddDto));
        }

        public async Task DeleteRoomAsync(int id)
        {
            await _roomRepository.DeleteRoomAsync(id);
        }

        public async Task<RoomDto> GetRoomByIdAsync(int id)
        {
            var room = await _roomRepository.GetRoomByIdAsync(id);
            var roomDto = _mapper.Map<RoomDto>(room);
            return roomDto;
        }

        public async Task<IEnumerable<RoomDto>> GetRoomsAsync()
        {
            var rooms = await _roomRepository.GetRoomsAsync();
            var roomDtos = _mapper.Map<IEnumerable<RoomDto>>(rooms);
            return roomDtos;
        }

        public async Task UpdateRoomAsync(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            room.RoomType = await _roomTypeRepository.GetRoomTypeByIdAsync(roomDto.RoomTypeId);
            await _roomRepository.UpdateRoomAsync(room);
        }
    }
}
