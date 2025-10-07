using SPSS.BusinessObject.DTOs.Brand;
using SPSS.BusinessObject.DTOs.ProductCategory;
using SPSS.BusinessObject.DTOs.ProductItem;
using SPSS.BusinessObject.DTOs.SkinType;

namespace SPSS.BusinessObject.DTOs.Product
{
    public class ProductWithDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int SoldCount { get; set; }

        public double Rating { get; set; }

        public decimal Price { get; set; }

        public decimal MarketPrice { get; set; }
        public string Status { get; set; } = null!;
        public string Thumbnail { get; set; } = null!;
        public List<SkinTypeForProductQueryDto> SkinTypes { get; set; } = new();
        public List<ProductItemDto> ProductItems { get; set; } = new();
        public BrandDto Brand { get; set; } = null!;
        public ProductCategoryDto Category { get; set; } = null!;
        public ProductSpecifications Specifications { get; set; } = new();
    }
}
