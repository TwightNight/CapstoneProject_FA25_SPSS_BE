namespace SPSS.BusinessObject.DTOs.ProductStatus
{
    public class ProductStatusDto
    {
        public Guid Id { get; set; }

        public string StatusName { get; set; } = null!;

        public string? Description { get; set; }
    }
}
