using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelBooking.Shared.DTO
{
    public class RoomUpdateImageDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }
    }
}
