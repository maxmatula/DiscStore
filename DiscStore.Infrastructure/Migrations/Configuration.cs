namespace DiscStore.Infrastructure.Migrations
{
    using DiscStore.Core.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiscStore.Infrastructure.DAL.DSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DiscStore.Infrastructure.DAL.DSDbContext context)
        {
            //comment after first seed

            //context.Categories.AddOrUpdate(x => x.CategoryID,
            //    new Category() {  Name = "POP", Description = "Muzyka popularna" },
            //    new Category() {  Name = "ROCK", Description = "Muzyka rockowa" },
            //    new Category() {  Name = "KLASYCZNA", Description = "Muzyka klasyczna" },
            //    new Category() {  Name = "METAL", Description = "Muzyka metal" },
            //    new Category() {  Name = "HIP-HOP", Description = "Muzyka hip-hop" },
            //    new Category() {  Name = "JAZZ", Description = "Muzyka jazz" },
            //    new Category() {  Name = "FANTASY", Description = "Muzyka fantasy" },
            //    new Category() {  Name = "FILMOWA", Description = "Muzyka filmowa" },
            //    new Category() {  Name = "DISCO", Description = "Muzyka disco" }
            //    );
        }
    }
}
