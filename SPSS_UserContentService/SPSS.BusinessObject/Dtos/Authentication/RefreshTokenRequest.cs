using System.ComponentModel.DataAnnotations;

namespace SPSS.BusinessObject.Dtos.Authentication;

public class RefreshTokenRequest
{
    
    [Required]
    public string AccessToken { get; set; }
    
    [Required]
    public string RefreshToken { get; set; }
}