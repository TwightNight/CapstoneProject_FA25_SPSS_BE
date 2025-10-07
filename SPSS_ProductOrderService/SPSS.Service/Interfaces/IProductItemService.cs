using SPSS.BusinessObject.DTOs.ProductItem;
using Microsoft.AspNetCore.Http;
using SPSS.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IProductItemService
    {
        Task<bool> UploadProductItemImage(List<IFormFile> files, Guid Id);

    }
}
