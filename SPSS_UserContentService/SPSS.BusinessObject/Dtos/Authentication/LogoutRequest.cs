using System.ComponentModel.DataAnnotations;

namespace SPSS.BusinessObject.Dtos.Authentication;

public class LogoutRequest
{
    [Required] public string RefreshToken { get; set; }
}