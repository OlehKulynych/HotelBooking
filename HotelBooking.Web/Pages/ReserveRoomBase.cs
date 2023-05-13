using HotelBooking.Shared.DTO;
using HotelBooking.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using static HotelBooking.Web.Pages.Message;

namespace HotelBooking.Web.Pages
{
    public class ReserveRoomBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IReservationService _reservationService { get; set; }

        [Inject]
        public IRoomService _roomService { get; set; }


        public ReservationAddDto reservationDto = new ReservationAddDto() { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1)};

        public RoomDto roomDto = new RoomDto();
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public string ErrorMessage { get; set; }

        [Inject]
        public IUserService _userService { get; set; }
        [Inject]
        AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }
        protected Message message = new Message();
        public string messageText { get; set; }
        public MessageType messageType { get; set; }

        protected bool isElementHidden = true;

        protected string GetElementStyle()
        {
            return isElementHidden ? "d-none" : string.Empty;
        }
        private void ShowSuccessMessage()
        {
            messageText = "Success Reserve";
            messageType = MessageType.Success;

            isElementHidden = false;
        }
        private void ShowErrorMessage(string message)
        {
            messageText = message;
            messageType = MessageType.Error;
            isElementHidden = false;
        }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                roomDto = await _roomService.GetRoomById(Id);
                var state = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();

                var user = state.User;
                reservationDto.UserId = (await _userService.GetCurrentUser(user.Identity.Name)).Id;
                reservationDto.Room = roomDto;
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }
        }
        protected async Task ReserveRoom()
        {
            try
            {
                await _reservationService.ReserveRoomAsync(reservationDto);
                ShowSuccessMessage();

            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
