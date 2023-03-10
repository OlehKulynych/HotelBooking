using HotelBooking.API.Interfaces;
using HotelBooking.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        public readonly IRoomTypeService _roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypeDto>>> Index()
        {
            var roomTypes = await _roomTypeService.GetRoomTypesAsync();
            if (roomTypes != null)
            {
                return Ok(roomTypes);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("RoomTypeById/{id}")]
        public async Task<ActionResult<RoomTypeDto>> GetRoomTypeById(int id)
        {
            var roomType = await _roomTypeService.GetRoomTypeByIdAsync(id);
            if (roomType != null)
            {
                return Ok(roomType);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddRoomType")]
        public async Task<ActionResult> AddRoomType(RoomTypeAddDto roomTypeAddDto)
        {
            await _roomTypeService.AddRoomTypeAsync(roomTypeAddDto);
            return Ok(roomTypeAddDto);
        }

        [HttpDelete]
        [Route("DeleteRoomType/{id}")]
        public async Task<ActionResult> DeleteRoomType(int id)
        {
            await _roomTypeService.DeleteRoomTypeAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateRoomType")]
        public async Task<ActionResult> UpdateRoomType(RoomTypeDto roomTypeDto)
        {
            await _roomTypeService.UpdateRoomTypeAsync(roomTypeDto);
            return Ok();
        }
    }
}
