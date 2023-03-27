namespace HotelBooking.Web.Static
{
    public class APIEndpoints
    {
#if DEBUG
        internal const string ServerBaseUrl = "https://localhost:7114";
#endif
        internal readonly static string s_register = $"{ServerBaseUrl}/api/User/Register";
        internal readonly static string s_signIn = $"{ServerBaseUrl}/api/User/signin";

    }
}
