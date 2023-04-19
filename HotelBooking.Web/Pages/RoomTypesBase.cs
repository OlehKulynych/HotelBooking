using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class RoomTypesBase: ComponentBase
    {

        public IEnumerable<RoomTypeDto> roomTypes;
        [Inject]
        public IRoomTypeService roomTypeService { get; set; }

        public string ErrorMessage { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            roomTypes = await roomTypeService.GetRoomTypesAsync();
        }

        protected async Task DeleteCategory(int id)
        {
            try
            {
                await roomTypeService.DeleteBookCategoryAsync(id);
                navigationManager.NavigateTo("/RoomTypes", true);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
