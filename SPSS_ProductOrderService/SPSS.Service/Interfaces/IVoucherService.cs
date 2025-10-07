using SPSS.BusinessObject.DTOs.Address;
using SPSS.BusinessObject.DTOs.Voucher;
using SPSS.Shared.Base;

namespace Services.Interface;

public interface IVoucherService
{
    Task<VoucherDto> GetByIdAsync(Guid id);
    Task<PagedResponse<VoucherDto>> GetPagedAsync(int pageNumber, int pageSize);
    Task<VoucherDto> CreateAsync(VoucherForCreationDto? voucherForCreationDto);
    Task<VoucherDto> UpdateAsync(Guid voucherId, VoucherForUpdateDto voucherForUpdateDto);
    Task DeleteAsync(Guid id);
    Task<VoucherDto> GetByCodeAsync(string voucherCode);
}