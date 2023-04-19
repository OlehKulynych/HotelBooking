using HotelBooking.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class DisplayRoomBase: ComponentBase
    {
        [Parameter]
        public IEnumerable<RoomDto> Rooms { get; set; }
        
        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected void Reserve(int Id)
        {
            navigationManager.NavigateTo($"/Room/Reserve/{Id}");
        }
    }
}
