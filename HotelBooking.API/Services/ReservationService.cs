using AutoMapper;
using HotelBooking.API.Interfaces;
using HotelBooking.API.Models;
using HotelBooking.API.Repository;
using HotelBooking.Shared.DTO;

namespace HotelBooking.API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task CancelReservationAsync(int id)
        {
            await _reservationRepository.CancelReservationAsync(id);
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsAsync()
        {
            var reservations = await _reservationRepository.GetReservationsAsync();
            var reservationDtos = _mapper.Map<IEnumerable<ReservationDto>>(reservations);
            return reservationDtos;
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsByUserIdAsync(string userId)
        {

            var reservations = await _reservationRepository.GetReservationsByUserIdAsync(userId);
            var reservationDtos = _mapper.Map<IEnumerable<ReservationDto>>(reservations);
            return reservationDtos;
        }

        public async Task ReserveRoomAsync(int id, ReservationAddDto reservationAddDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationAddDto);
            await _reservationRepository.ReserveRoomAsync(id, reservation);
        }
    }
}
