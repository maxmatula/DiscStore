using AutoMapper;
using DiscStore.Core.Entities;
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
                cfg.CreateMap<Product, ProductViewModel>();
            });
        }
    }
}