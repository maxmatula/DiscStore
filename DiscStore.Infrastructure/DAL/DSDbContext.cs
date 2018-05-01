using DiscStore.Core.Entities;
using System.Data.Entity;

namespace DiscStore.Infrastructure.DAL
{
    public class DSDbContext : DbContext
    {
        public DSDbContext() : base("DSDbContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
