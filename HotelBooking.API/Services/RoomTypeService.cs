using AutoMapper;
using HotelBooking.API.Interfaces;
using HotelBooking.API.Models;
using HotelBooking.Shared.DTO;

namespace HotelBooking.API.Services
{
    public class RoomTypeService : IRoomTypeService
    {

        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;


        public RoomTypeService(IRoomTypeRepository roomTypeRepository, IMapper mapper)
        {
            _roomTypeRepository = roomTypeRepository;
            _mapper = mapper;
        }

        public async Task AddRoomTypeAsync(RoomTypeAddDto roomTypeAddDto)
        {
            var roomType = _mapper.Map<RoomType>(roomTypeAddDto);
            await _roomTypeRepository.AddRoomTypeAsync(roomType);
        }

        public async Task DeleteRoomTypeAsync(int id)
        {
            await _roomTypeRepository.DeleteRoomTypeAsync(id);
        }

        public async Task<RoomTypeDto> GetRoomTypeByIdAsync(int id)
        {
            var roomType = await _roomTypeRepository.GetRoomTypeByIdAsync(id);
            var roomTypeDto = _mapper.Map<RoomTypeDto>(roomType);
            return roomTypeDto;
        }

        public async Task<IEnumerable<RoomTypeDto>> GetRoomTypesAsync()
        {
            var roomType = await _roomTypeRepository.GetRoomTypesAsync();
            var roomTypeDtos = _mapper.Map<List<RoomTypeDto>>(roomType);
            return roomTypeDtos;

        }

        public async Task UpdateRoomTypeAsync(RoomTypeDto roomTypeDto)
        {
            var roomType = _mapper.Map<RoomType>(roomTypeDto);
            await _roomTypeRepository.UpdateRoomTypeAsync(roomType);
        }
    }
}
