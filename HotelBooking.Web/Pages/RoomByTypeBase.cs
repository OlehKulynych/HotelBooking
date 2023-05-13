using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using static HotelBooking.Web.Pages.Message;

namespace HotelBooking.Web.Pages
{
    public class RoomByTypeBase: ComponentBase
    {
        [Inject]
        public IRoomService roomService { get; set; }
        [Inject]
        public IRoomTypeService roomTypeService { get; set; }
        [Parameter]
        public int Id { get; set; }
        public IEnumerable<RoomDto> Rooms { get; set; }
        public RoomTypeDto typeDto { get; set; }
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
                typeDto = await roomTypeService.GetRoomTypeByIdAsync(Id);
                Rooms = await roomService.GetRoomByTypeIdAsync(Id);

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }


        }
    }
}
