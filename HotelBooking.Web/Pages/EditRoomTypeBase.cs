using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static HotelBooking.Web.Pages.Message;

namespace HotelBooking.Web.Pages
{
    public class EditRoomTypeBase: ComponentBase
    {
        [Inject]
        public IRoomTypeService roomTypeService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        public RoomTypeDto roomType = new RoomTypeDto();

        [Parameter]
        public int Id { get; set; }
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
            messageText = "Success Edit";
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

                roomType = await roomTypeService.GetRoomTypeByIdAsync(Id);
            }
            catch(Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
        public string ErrorMessage { get; set; }


        protected async Task UpdateRoomType()
        {

            try
            {
                bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
                if (confirmed)
                {

                    await roomTypeService.UpdateRoomTypeAsync(roomType);
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
