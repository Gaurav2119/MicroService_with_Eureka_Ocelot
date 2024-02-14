namespace UserAuthenticationAPI.JwtAuthenticationManager.Models
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public string JwtToken { get; set; }
        public int ExpiresInMins { get; set; }
    }
}
