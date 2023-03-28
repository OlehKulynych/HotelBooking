using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

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

        protected async Task AddBookCategory()
        {
            try
            {
                await roomTypeService.AddBookCategoryAsync(roomType);
                navigationManager.NavigateTo("/RoomTypes");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
