using SPSS.BusinessObject.DTOs.Country;

namespace SPSS.BusinessObject.DTOs.Brand
{
    public class BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsLiked { get; set; }
        public CountryDto Country { get; set; }
        public int CountryId { get; set; }
    }
}
