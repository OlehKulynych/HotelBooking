using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static HotelBooking.Web.Pages.Message;

namespace HotelBooking.Web.Pages
{
    public class RoomTypesBase: ComponentBase
    {

        public IEnumerable<RoomTypeDto> roomTypes;
        [Inject]
        public IRoomTypeService roomTypeService { get; set; }
        [Inject] protected IJSRuntime JSRuntime { get; set; }
        public string ErrorMessage { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
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
            messageText = "Success Deleted";
            messageType = MessageType.Success;

            isElementHidden = false;
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

                roomTypes = await roomTypeService.GetRoomTypesAsync();
            }
            catch(Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        protected async Task DeleteCategory(int id)
        {
            try
            {

                bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
                if (confirmed)
                {

                    await roomTypeService.DeleteBookCategoryAsync(id);
                    ShowSuccessMessage();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
