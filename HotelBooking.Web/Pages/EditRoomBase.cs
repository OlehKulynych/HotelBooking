using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace HotelBooking.Web.Pages
{
    public class EditRoomBase: ComponentBase
    {
        [Inject]
        public IRoomService roomService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public RoomDto room = new RoomDto();
        [Inject]
        public IRoomTypeService _roomTypeService { get; set; }

        protected List<RoomTypeDto>? roomTypeDtos = new List<RoomTypeDto>();
        private string image = null;

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            room = await roomService.GetRoomById(Id);

            roomTypeDtos = (await _roomTypeService.GetRoomTypesAsync()).ToList();
        }
        public string ErrorMessage { get; set; }

        protected async Task UpdateBook()
        {

            try
            {
                await roomService.UpdateBookAsync(room);
                navigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
