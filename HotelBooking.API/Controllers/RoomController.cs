using HotelBooking.API.Interfaces;
using HotelBooking.API.Services;
using HotelBooking.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> Index()
        {
            var rooms = await _roomService.GetRoomsAsync();
            if (rooms != null)
            {
                return Ok(rooms);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoomDto>> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room != null)
            {
                return Ok(room);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("RoomByType/{id:int}")]
        public async Task<ActionResult<RoomDto>> GetRoomByTypeId(int id)
        {
            var room = await _roomService.GetRoomByTypeIdAsync(id);
            if (room != null)
            {
                return Ok(room);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddRoom")]
        public async Task<ActionResult> AddRoom(RoomAddDto roomAddDto)
        {
            await _roomService.AddRoomAsync(roomAddDto);
            return Ok(roomAddDto);
        }

        [HttpDelete]
        [Route("DeleteRoom/{id}")]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateRoom")]
        public async Task<ActionResult> UpdateRoom(RoomDto roomDto)
        {
            await _roomService.UpdateRoomAsync(roomDto);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateImage")]
        public async Task<ActionResult> UpdateImage(RoomUpdateImageDto roomUpdateImage)
        {

            await _roomService.UpdateImageAsync(roomUpdateImage);
            return Ok();

        }

      
    }
}
