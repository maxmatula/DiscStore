using AutoMapper;
using DiscStore.Core.Entities;
using DiscStore.Infrastructure.ViewModels.Category;
using DiscStore.Infrastructure.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscStore.WebUI
{
    public partial class Startup
    {
        public void MapperInitialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>()
                .ForMember(f => f.Categories, x => x.Ignore());
                cfg.CreateMap<Category, CategoryViewModel>()
                .ForMember(g => g.Products, x => x.Ignore());

            });
        }
    }
}