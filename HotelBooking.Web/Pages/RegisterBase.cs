using HotelBooking.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace HotelBooking.Web.Pages
{
    public class RegisterBase: ComponentBase
    {

        [Inject]
        public HttpClient httpClient { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        protected RegisterUserDto _registerUserDto = new() { EmailAddress = "user@example.com", Password = "Qwe123!", Name = "admin", Surname = "admin" };
        protected bool _registerSuccessful = false;
        protected bool _attemptToRegisterFailed = false;
        protected string? _attemptToRegisterFailedErrorMessage = null;


        protected override async Task OnInitializedAsync()
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/HidePassword.js");
        }
        public async Task HidePassword()
        {
            await _jsModule.InvokeVoidAsync("hidePassword");
        }


        protected async Task RegisterUser()
        {
            _attemptToRegisterFailed = false;
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("/api/User/Register", _registerUserDto);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                _registerSuccessful = true;
            }
            else
            {
                string serverErrorMessages = await httpResponseMessage.Content.ReadAsStringAsync();

                _attemptToRegisterFailedErrorMessage = $"{serverErrorMessages} Try Again...";

                _attemptToRegisterFailed = true;
            }
        }
    }
}
