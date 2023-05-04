using HotelBooking.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class DisplayReservationBase: ComponentBase
    {
        [Parameter]
        public IEnumerable<ReservationDto> reservationDtos { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

    }
}
