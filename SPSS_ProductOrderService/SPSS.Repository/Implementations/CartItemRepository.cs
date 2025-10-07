using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.Context;
using SPSS.BusinessObject.DTOs;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Implementations
{
    public class CartItemRepository : RepositoryBase<CartItem, Guid>, ICartItemRepository
    {
        public CartItemRepository(ProductOrderDBContext context) : base(context)
        {
        }
    }
}
