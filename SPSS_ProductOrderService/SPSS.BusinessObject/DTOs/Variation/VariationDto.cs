using SPSS.BusinessObject.DTOs.ProductCategory;
using SPSS.BusinessObject.DTOs.VariationOption;

namespace SPSS.BusinessObject.DTOs.Variation
{
    public class VariationDto
    {
        public Guid Id { get; set; }
        public CategoryForVariationQuery ProductCategory { get; set; }
        public List<VariationOptionForVariationQuery> VariationOptions { get; set; }
        public string Name { get; set; }
        public ProductCategoryDto ProductCategoryDto { get; set; }
    }
}