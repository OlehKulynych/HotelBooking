using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelBooking.Shared.DTO
{
    public class RoomTypeAddDto
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
