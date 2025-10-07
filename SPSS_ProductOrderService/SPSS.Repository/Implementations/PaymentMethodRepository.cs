using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using SPSS.Shared.Base;
using SPSS.Repository.Interfaces;
using SPSS.BusinessObject.Context;

namespace SPSS.Repository.Implementations
{
    public class PaymentMethodRepository : RepositoryBase<PaymentMethod, Guid>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(ProductOrderDBContext repositoryContext)
                : base(repositoryContext)
        {
        }
    }
}
