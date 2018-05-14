using DiscStore.Core.Entities;
using DiscStore.Infrastructure.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace DiscStore.Infrastructure.Services.Abstract
{
    public interface IProductService
    {
        bool Create(ProductViewModel product, string fileStream);
        bool Delete(Guid productId);
        bool Edit(ProductViewModel product, HttpPostedFileBase file);
        ProductViewModel GetCreateModel();
        ProductViewModel GetProductVMById(Guid productId);
        Product GetProductById(Guid productId);
        List<ProductViewModel> GetProductVMList();
        List<ProductViewModel> GetNewProductVMList();

    }
}
