using SPSS.BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using SPSS.BusinessObject.DTOs;
using System.Linq.Expressions;
using SPSS.Shared.Base;
using SPSS.BusinessObject.Context;
using SPSS.Repository.Interfaces;

namespace SPSS.Repository.Implementations
{
    public class StatusChangeRepository : RepositoryBase<StatusChange, Guid>, IStatusChangeRepository
    {
        public StatusChangeRepository(ProductOrderDBContext context) : base(context)
        {
        }

        public async Task<StatusChange> FirstOrDefaultAsync(Expression<Func<StatusChange, bool>> predicate)
        {
            return await _context.StatusChanges.FirstOrDefaultAsync(predicate);
        }
    }
}
