using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using static HotelBooking.Web.Pages.Message;

namespace HotelBooking.Web.Pages
{
    public class RoomsBase: ComponentBase
    {
        [Inject]
        public IRoomService roomService { get; set; }

        public IEnumerable<RoomDto> Rooms { get; set; }

        public FilterRoomDto filter = new FilterRoomDto() { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1) };
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
                Rooms = await roomService.GetRoomsAsync();

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }


        }

        protected async Task GetAvailableRoomsAsync(FilterRoomDto filterRoom)
        {
            try
            {
                Rooms = await roomService.GetAvailableRoomsAsync(filterRoom);
            }
            catch(Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

    }
}
 