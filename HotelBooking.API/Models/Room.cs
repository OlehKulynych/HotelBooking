namespace HotelBooking.API.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfBeds { get; set; }
        public string? Description { get; set; }
        public int RoomTypeId { get; set; }
        public bool isAvailable { get; set; }
        public decimal Price { get; set; }
        public string? ImageString { get; set; }  
        public virtual RoomType RoomType { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
