using System.ComponentModel.DataAnnotations;

namespace SPSS.BusinessObject.Dtos.Country;

public class CountryForCreationDto
{
    [Required(ErrorMessage = "Country ID is required.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Country code is required.")]
    [StringLength(10, ErrorMessage = "Country code can't exceed 10 characters.")]
    public string CountryCode { get; set; }

    [Required(ErrorMessage = "Country name is required.")]
    [StringLength(100, ErrorMessage = "Country name can't exceed 100 characters.")]
    public string CountryName { get; set; }
}
