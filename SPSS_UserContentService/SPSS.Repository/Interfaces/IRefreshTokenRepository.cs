using SPSS.BusinessObject.Models;
using SPSS.Shared.Base;

namespace SPSS.Repository.Interfaces;

public interface IRefreshTokenRepository : IRepositoryBase<RefreshToken, Guid>
{
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task<IEnumerable<RefreshToken?>> GetByUserIdAsync(Guid userId);
}