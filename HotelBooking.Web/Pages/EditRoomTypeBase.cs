using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class EditRoomTypeBase: ComponentBase
    {
        [Inject]
        public IRoomTypeService roomTypeService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public RoomTypeDto roomType = new RoomTypeDto();

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            roomType = await roomTypeService.GetRoomTypeByIdAsync(Id);
        }
        public string ErrorMessage { get; set; }

        protected async Task UpdateCategory()
        {

            try
            {
                await roomTypeService.UpdateRoomTypeAsync(roomType);
                navigationManager.NavigateTo("/RoomTypes");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
