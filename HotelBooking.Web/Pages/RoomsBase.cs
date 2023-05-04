using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class RoomsBase: ComponentBase
    {
        [Inject]
        public IRoomService roomService { get; set; }

        public IEnumerable<RoomDto> Rooms { get; set; }

        public FilterRoomDto filter = new FilterRoomDto() { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1) };
        public string ErrorMessage { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Rooms = await roomService.GetRoomsAsync();

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }


        }

        protected async Task GetAvailableRoomsAsync(FilterRoomDto filterRoom)
        {
            try
            {
                Rooms = await roomService.GetAvailableRoomsAsync(filterRoom);
            }
            catch(Exception ex)
            {
                
            }
        }

    }
}
 