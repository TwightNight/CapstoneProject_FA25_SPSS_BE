using System.ComponentModel.DataAnnotations;

namespace SPSS.BusinessObject.Dtos.Authentication;

public class LoginRequest
{
    [Required]
    public string UsernameOrEmail { get; set; }
    
    [Required]
    public string Password { get; set; }
}