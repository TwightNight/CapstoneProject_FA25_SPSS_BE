using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.DTOs;
using SPSS.Shared.Base;
using SPSS.BusinessObject.Context;
using SPSS.Repository.Interfaces;

namespace SPSS.Repository.Implementations;

public class VoucherRepository : RepositoryBase<Voucher, Guid>, IVoucherRepository
{
    public VoucherRepository(ProductOrderDBContext context) : base(context)
    {
    }
}