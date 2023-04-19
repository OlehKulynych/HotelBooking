namespace HotelBooking.API.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual StatusReservation StatusReservation { get; set; }
        public virtual User User { get; set; }
        public virtual Room Room { get; set; }
    }
}
