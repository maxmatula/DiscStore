using DiscStore.Core.Entities;
using DiscStore.Infrastructure.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DiscStore.Infrastructure.Services.Abstract
{
    public interface IProductService
    {
        bool Create(Product product, HttpPostedFileBase file);
        bool Delete(Guid productId);
        bool Edit(Product product, HttpPostedFileBase file);
        ProductViewModel GetById(Guid productId);
        List<ProductViewModel> GetList();

    }
}
