using System.ComponentModel.DataAnnotations;

namespace SPSS.BusinessObject.DTOs.Variation
{
    public class VariationForProductUpdateDto
    {
        public Guid? Id { get; set; }

        [MinLength(1, ErrorMessage = "At least one variation option ID is required.")]
        public List<Guid>? VariationOptionIds { get; set; }
    }
}
