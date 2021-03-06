﻿using DiscStore.Core.Entities;
using DiscStore.Core.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Data.Entity;

namespace DiscStore.Infrastructure.DAL
{
    public class DSDbContext : IdentityDbContext<AppUser>
    {
        public DSDbContext() : base("DSDbContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }

        public static DSDbContext Create()
        {
            return new DSDbContext();
        }
    }

    

}
