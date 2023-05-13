using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using static HotelBooking.Web.Pages.Message;

namespace HotelBooking.Web.Pages
{
    public class EditImageRoomBase: ComponentBase
    {
        [Inject]
        public IRoomService roomService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        public RoomDto room = new RoomDto();

        public RoomUpdateImageDto imagebook = new RoomUpdateImageDto();

        [Parameter]
        public int Id { get; set; }

        public string ErrorMessage { get; set; }

        protected string contentString = null;
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
            room = await roomService.GetRoomById(Id);
            contentString = $"data:image/jpeg;base64,{room.ImageString}";
        }
        protected async Task UpdateImage()
        {

            try
            {
                bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
                if (confirmed)
                {

                    imagebook.Id = room.Id;
                    imagebook.Image = room.ImageString;

                    await roomService.UpdateImageAsync(imagebook);
                    ShowSuccessMessage();
                }
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
