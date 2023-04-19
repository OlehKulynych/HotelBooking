﻿namespace HotelBooking.API.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
