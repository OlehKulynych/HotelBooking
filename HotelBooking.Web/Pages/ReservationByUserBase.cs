using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using static HotelBooking.Web.Pages.Message;

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
        protected Message message = new Message();
        public string messageText { get; set; }
        public MessageType messageType { get; set; }

        protected bool isElementHidden = true;

        protected string GetElementStyle()
        {
            return isElementHidden ? "d-none" : string.Empty;
        }
        
        private void ShowErrorMessage(string message)
        {
            messageText = message;
            messageType = MessageType.Error;
            isElementHidden = false;
        }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                reservationDtos = await _reservationService.GetReservationByUserIdAsync(userId);

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }

        }

    }
}
