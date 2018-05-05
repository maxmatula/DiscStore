﻿using DiscStore.Core.Entities;
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
        bool Create(ProductViewModel product, HttpPostedFileBase file);
        bool Delete(Guid productId);
        bool Edit(ProductViewModel product, HttpPostedFileBase file);
        ProductViewModel GetCreateModel();
        ProductViewModel GetById(Guid productId);
        List<ProductViewModel> GetList();
        List<ProductViewModel> GetNewProductList();

    }
}