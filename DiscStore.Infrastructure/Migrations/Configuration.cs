namespace DiscStore.Infrastructure.Migrations
{
    using DiscStore.Core.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<DiscStore.Infrastructure.DAL.DSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DiscStore.Infrastructure.DAL.DSDbContext context)
        {

        }
    }
}

















































