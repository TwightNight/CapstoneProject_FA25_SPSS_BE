using System;

namespace SPSS.BusinessObject.DTOs.ProductCategory
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public List<ProductCategoryDto> Children { get; set; } = new List<ProductCategoryDto>();
    }

}
