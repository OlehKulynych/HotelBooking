using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HotelBooking.Web.Pages
{
    public class DisplayRoomBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<RoomDto> Rooms { get; set; }

        [Inject]
        public IRoomService roomService { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        public FilterRoomDto filter = new FilterRoomDto() { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1) };
        [Inject]
        public NavigationManager navigationManager { get; set; }



        protected void Reserve(int Id)
        {
            navigationManager.NavigateTo($"/Reservation/Reserve/{Id}");
        }

        protected async Task GetAvailableRoomsAsync(FilterRoomDto filterRoom)
        {
            try
            {
                Rooms = await roomService.GetAvailableRoomsAsync(filterRoom);
            }
            catch (Exception ex)
            {

            }
        }

        protected async Task DeleteRoom(int id)
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
            if (confirmed)
            {
                await roomService.DeleteRoomAsync(id);
            }

        }
    }
}
