using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using static HotelBooking.Web.Pages.Message;

namespace HotelBooking.Web.Pages
{
    public class AddRoomTypeBase: ComponentBase
    {
        [Inject]
        public IRoomTypeService roomTypeService { get; set; }

        public RoomTypeAddDto roomType = new RoomTypeAddDto();

        [Inject]
        public NavigationManager navigationManager { get; set; }
        public string ErrorMessage { get; set; }
        protected Message message = new Message();
        public string messageText { get; set; }
        public MessageType messageType { get; set; }

        protected bool isElementHidden = true;

        protected string GetElementStyle()
        {
            return isElementHidden ? "d-none" : string.Empty;
        }
        private void ShowSuccessMessage()
        {
            messageText = "Success Added";
            messageType = MessageType.Success;

            isElementHidden = false;
        }
        private void ShowErrorMessage(string message)
        {
            messageText = message;
            messageType = MessageType.Error;
            isElementHidden = false;
        }

        protected async Task AddNewRoomType()
        {
            try
            {
                await roomTypeService.AddBookCategoryAsync(roomType);
                ShowSuccessMessage();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }

        }
    }
}
