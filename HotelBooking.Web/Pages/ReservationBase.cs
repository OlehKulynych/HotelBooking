using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using static HotelBooking.Web.Pages.Message;

namespace HotelBooking.Web.Pages
{
    public class ReservationBase: ComponentBase
    {
        [Inject]
        public IReservationService reservationService { get; set; }

        public IEnumerable<ReservationDto> reservationDtos { get; set; }
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
                reservationDtos = await reservationService.GetReservationsAsync();
                

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }

        }
    }
}
