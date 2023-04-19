using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HotelBooking.Web.Pages
{
    public class ReserveRoomBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IRoomService _roomService { get; set; }

        public ReservationDto reservationDto = new ReservationDto() { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1)};

        public RoomDto roomDto = new RoomDto();
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public string ErrorMessage { get; set; }

        [Inject]
        public IUserService _userService { get; set; }
        [Inject]
        AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                roomDto = await _roomService.GetRoomById(Id);
                var state = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();

                var user = state.User;
                reservationDto.UserId = (await _userService.GetCurrentUser(user.Identity.Name)).Id;
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        protected async Task ReserveRoom()
        {
            try
            {
                await _roomService.ReserveRoomAsync(Id, reservationDto);
                navigationManager.NavigateTo("/");

            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
