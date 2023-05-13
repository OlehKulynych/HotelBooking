using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HotelBooking.Web.Pages
{
    public class DisplayReservationBase: ComponentBase
    {
        [Parameter]
        public IEnumerable<ReservationDto> reservationDtos { get; set; }

        [Inject]
        protected IReservationService reservationService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        protected async Task CancelReservation(int id)
        {

            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
            if (confirmed)
            {

                await reservationService.CancelReservationAsync(id);
                navigationManager.NavigateTo(navigationManager.Uri, forceLoad: true);
            }
        }

    }
}
