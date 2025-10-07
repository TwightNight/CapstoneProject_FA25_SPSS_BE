using System.ComponentModel.DataAnnotations;

namespace SPSS.BusinessObject.DTOs.PaymentMethod
{
    public class PaymentMethodForUpdateDto
    {
        [Required(ErrorMessage = "Payment type is required.")]
        [StringLength(50, ErrorMessage = "Payment type can't exceed 50 characters.")]
        public string PaymentType { get; set; }

        [Url(ErrorMessage = "Invalid URL format for Image URL.")]
        public string ImageUrl { get; set; }
    }
}
