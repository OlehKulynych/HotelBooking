using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class ReservationByUserBase: ComponentBase
    {
        [Inject]
        public IReservationService _reservationService { get; set; }

        public IEnumerable<ReservationDto> reservationDtos { get; set; }

        [Parameter]
        public string userId { get; set; }
        public string ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                reservationDtos = await _reservationService.GetReservationByUserIdAsync(userId);

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }

        protected async Task CancelReservation(int id)
        {
            await _reservationService.CancelReservationAsync(id);
        }
    }
}
