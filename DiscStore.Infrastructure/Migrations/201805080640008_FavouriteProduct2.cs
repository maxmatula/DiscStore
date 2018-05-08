namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavouriteProduct2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "FavouriteProduct_FavouriteID", "dbo.FavouriteProducts");
            DropIndex("dbo.Products", new[] { "FavouriteProduct_FavouriteID" });
            AddColumn("dbo.FavouriteProducts", "ProductID", c => c.Guid(nullable: false));
            DropColumn("dbo.Products", "FavouriteProduct_FavouriteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "FavouriteProduct_FavouriteID", c => c.Guid());
            DropColumn("dbo.FavouriteProducts", "ProductID");
            CreateIndex("dbo.Products", "FavouriteProduct_FavouriteID");
            AddForeignKey("dbo.Products", "FavouriteProduct_FavouriteID", "dbo.FavouriteProducts", "FavouriteID");
        }
    }
}
