using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.Models;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Implementations;

public class ProductForSkinTypeRepository : RepositoryBase<ProductForSkinType, Guid>, IProductForSkinTypeRepository
{
    public ProductForSkinTypeRepository(SkinAnalysisDBContext context) : base(context)
    {
    }
}
