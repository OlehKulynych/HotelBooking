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
    }
}
