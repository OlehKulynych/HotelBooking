using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelBooking.Shared.DTO
{
    public class RoomAddDto
    {
        
        [Display(Name = "Room Number")]
        [Range(1,int.MaxValue, ErrorMessage = "Must be greater than zero.")]
        public int RoomNumber { get; set; }
        
        [Display(Name = "Number of Beds")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than zero.")]
        public int NumberOfBeds { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        
        [Display(Name = "Room Type")]
        [Range(1, int.MaxValue, ErrorMessage = "RoomType Required")]
        public int RoomTypeId { get; set; }
        public bool isAvailable { get; set; }

        
        [Display(Name = "Price")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than zero.")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string? ImageString { get; set; }
        public string? ImageName { get; set; }
    }
}
