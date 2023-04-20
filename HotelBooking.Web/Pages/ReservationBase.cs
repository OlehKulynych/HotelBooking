using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class ReservationBase: ComponentBase
    {
        [Inject]
        public IReservationService reservationService { get; set; }

        public IEnumerable<ReservationDto> reservationDtos { get; set; }
        public string ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                reservationDtos = await reservationService.GetReservationsAsync();

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
