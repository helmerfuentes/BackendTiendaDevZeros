namespace Application.Http.Responses
{
    public class LoginUserResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string Rol { get; set; }
        public string RememberToken { get; set; }
    }
}