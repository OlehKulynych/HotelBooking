using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using static HotelBooking.Web.Pages.Message;

namespace HotelBooking.Web.Pages
{
    public class AddRoomBase : ComponentBase
    {
        [Inject]
        public IRoomService _roomService { get; set; }

        [Inject]
        public IRoomTypeService _roomTypeService { get; set; }

        protected List<RoomTypeDto> roomTypeDtos = new List<RoomTypeDto>();

        protected string contentString = null;

        public RoomAddDto room = new RoomAddDto();
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
        protected override async Task OnInitializedAsync()
        {

            try
            {
                roomTypeDtos = (await _roomTypeService.GetRoomTypesAsync()).ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }

        }

        

        protected async Task AddNewRoom()
        {
            try
            {
                await _roomService.AddRoomAsync(room);
                ShowSuccessMessage();
                

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }

        }

        protected async Task OnInputFileChanged(InputFileChangeEventArgs inputFileChangeEventArgs)
        {
            try
            {
                var img = inputFileChangeEventArgs.File;

                var resizedImg = await img.RequestImageFileAsync(img.ContentType, 640, 480);
                var buffer = new byte[resizedImg.Size];

                await resizedImg.OpenReadStream().ReadAsync(buffer);

                room.ImageString = Convert.ToBase64String(buffer);
                room.ImageName = img.Name;
                contentString = $"data:{resizedImg.ContentType};base64,{Convert.ToBase64String(buffer)}";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }

        }
    }
}
