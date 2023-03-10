using HotelBooking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.API.Repository.DataBaseContext
{
    public class HotelBookingDataBaseContext : DbContext
    {
        public HotelBookingDataBaseContext(DbContextOptions<HotelBookingDataBaseContext> options) : base(options)
        {

        }


        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


    }
}
