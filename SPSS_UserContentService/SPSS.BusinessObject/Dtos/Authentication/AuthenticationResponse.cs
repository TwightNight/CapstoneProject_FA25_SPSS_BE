namespace SPSS.BusinessObject.Dtos.Authentication;

public class AuthenticationResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    // public AuthUserDto AuthUserDto { get; set; }
}