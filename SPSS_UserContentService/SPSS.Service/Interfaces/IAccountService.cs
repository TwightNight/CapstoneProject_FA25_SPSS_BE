using Microsoft.AspNetCore.Http;
using SPSS.BusinessObject.Dtos.Account;

namespace SPSS.Service.Interfaces;

public interface IAccountService
{
    Task<AccountDto> GetAccountInfoAsync(Guid userId);
    Task<AccountDto> UpdateAccountInfoAsync(Guid userId, AccountForUpdateDto accountUpdateDto);
    Task<string> UpdateAvatarAsync(Guid userId, IFormFile avatarFile);
    Task<bool> DeleteFirebaseLink(string imageUrl);
}
