using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class ConfirmDialogBase: ComponentBase
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string ConfirmationMessage { get; set; }

        [Parameter]
        public EventCallback OnConfirm { get; set; }

        protected bool IsOpen { get; set; }

        public void Show()
        {
            IsOpen = true;
        }

        public void Close()
        {
            IsOpen = false;
        }

        public async Task Confirm()
        {
            await OnConfirm.InvokeAsync();
            Close();
        }
    }
}
