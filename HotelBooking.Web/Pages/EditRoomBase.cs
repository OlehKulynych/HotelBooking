using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static HotelBooking.Web.Pages.Message;

namespace HotelBooking.Web.Pages
{
    public class EditRoomBase: ComponentBase
    {
        [Inject]
        public IRoomService roomService { get; set; }
        [Inject] protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public RoomDto room = new RoomDto();
        [Inject]
        public IRoomTypeService _roomTypeService { get; set; }

        protected List<RoomTypeDto>? roomTypeDtos = new List<RoomTypeDto>();
        private string image = null;

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
                room = await roomService.GetRoomById(Id);

                roomTypeDtos = (await _roomTypeService.GetRoomTypesAsync()).ToList();
                ShowSuccessMessage();
            }
            catch(Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }

        }
        public string ErrorMessage { get; set; }

        protected async Task UpdateRoom()
        {

            try
            {

                bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
                if (confirmed)
                {

                    await roomService.UpdateBookAsync(room);
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
