using SPSS.BusinessObject.DTOs.ProductConfiguration;

namespace SPSS.BusinessObject.DTOs.ProductItem
{
    public class ProductItemDto
    {
        public Guid Id { get; set; }

        public int QuantityInStock { get; set; }

        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal MarketPrice { get; set; }

        public decimal PurchasePrice { get; set; }

        public List<ProductConfigurationForProductQueryDto> Configurations { get; set; } = new();
    }
}
