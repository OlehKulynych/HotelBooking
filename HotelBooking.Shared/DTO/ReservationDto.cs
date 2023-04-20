﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Shared.DTO
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string StatusReservationName { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
