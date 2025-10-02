using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;

namespace SPSS.Repository.Implementations;

public class SkinTypeRepository : RepositoryBase<SkinType, Guid>, ISkinTypeRepository
{
    public SkinTypeRepository(UserDBContext context) : base(context)
    {
    }
}
