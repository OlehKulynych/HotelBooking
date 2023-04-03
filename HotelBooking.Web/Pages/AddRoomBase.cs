using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class AddRoomBase: ComponentBase
    {
        [Inject]
        public IRoomService _roomService { get; set; }

        [Inject]
        public IRoomTypeService _roomTypeService { get; set; }

        protected List<RoomTypeDto> roomTypeDtos = new List<RoomTypeDto>();

        protected string contentString = null;

        public RoomAddDto room = new RoomAddDto();
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public string ErrorMessage { get; set; }


        protected override async Task OnInitializedAsync()
        {

            try
            {
                roomTypeDtos = (await _roomTypeService.GetRoomTypesAsync()).ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
        protected async Task AddBook()
        {
            try
            {
                await _roomService.AddRoomAsync(room);
                navigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
