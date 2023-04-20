using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class RoomByTypeBase: ComponentBase
    {
        [Inject]
        public IRoomService roomService { get; set; }
        [Parameter]
        public int Id { get; set; }
        public IEnumerable<RoomDto> Rooms { get; set; }
        public string ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Rooms = await roomService.GetRoomByTypeIdAsync(Id);

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }


        }
    }
}
