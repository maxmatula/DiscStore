using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.DAL
{
    public class DSDbContext : DbContext
    {
        public DSDbContext() : base("DSDbContext")
        {
        }

        //DbSet - here
    }
}
