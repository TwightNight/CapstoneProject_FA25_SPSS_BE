using SPSS.BusinessObject.Models;
using SPSS.Shared.Base;
using System.Linq.Expressions;

namespace SPSS.Repository.Interfaces
{
    public interface IStatusChangeRepository : IRepositoryBase<StatusChange, Guid>
    {
        Task<StatusChange> FirstOrDefaultAsync(Expression<Func<StatusChange, bool>> predicate);
    }
}
