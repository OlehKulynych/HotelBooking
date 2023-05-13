using HotelBooking.API.Interfaces;
using HotelBooking.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IReservationService _reservationService;
        public ReservationController(IRoomService roomService, IReservationService reservationService)
        {
            _roomService = roomService;
            _reservationService = reservationService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> Index()
        {
            var reservation = await _reservationService.GetReservationsAsync();
            if (reservation != null)
            {
                return Ok(reservation);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("UserReservation/{userId}")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> ReservationByUserId(string userId)
        {
            var reservation = await _reservationService.GetReservationsByUserIdAsync(userId);
            if (reservation != null)
            {
                return Ok(reservation);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("CancelReservation/{id}")]
        public async Task<ActionResult> CancelReservation(int id)
        {
            await _reservationService.CancelReservationAsync(id);
            return Ok();
        }

        [HttpPost]
        [Route("Reserve/{id}")]
        public async Task<IActionResult> ReserveRoom([FromBody] ReservationAddDto reservationDto)
        {
            try
            {
                await _reservationService.ReserveRoomAsync(reservationDto);
                return Ok();
            }
            catch (Exception ex )
            {
                return BadRequest("This room is not available for the selected dates. " + ex.Message) ;
            }
        }
    }
}
