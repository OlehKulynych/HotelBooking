using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Shared.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfBeds { get; set; }
        public string? Description { get; set; }
        public int RoomTypeId { get; set; }
        public bool isAvailable { get; set; }
        public decimal Price { get; set; }
        public string RoomTypeName { get; set; }
    }
}
