using System.ComponentModel.DataAnnotations;

namespace SPSS.BusinessObject.DTOs.Variation
{
    public class VariationForCreationDto
    {
        public Guid? ProductCategoryId { get; set; }

        [Required(ErrorMessage = "Variation name is required.")]
        [StringLength(100, ErrorMessage = "Variation name cannot exceed 100 characters.")]
        public string Name { get; set; }
    }
}
