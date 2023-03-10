﻿namespace HotelBooking.API.Models
{
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
