namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavouriteProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavouriteProducts",
                c => new
                    {
                        FavouriteID = c.Guid(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FavouriteID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            AddColumn("dbo.Products", "FavouriteProduct_FavouriteID", c => c.Guid());
            CreateIndex("dbo.Products", "FavouriteProduct_FavouriteID");
            AddForeignKey("dbo.Products", "FavouriteProduct_FavouriteID", "dbo.FavouriteProducts", "FavouriteID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavouriteProducts", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "FavouriteProduct_FavouriteID", "dbo.FavouriteProducts");
            DropIndex("dbo.FavouriteProducts", new[] { "UserID" });
            DropIndex("dbo.Products", new[] { "FavouriteProduct_FavouriteID" });
            DropColumn("dbo.Products", "FavouriteProduct_FavouriteID");
            DropTable("dbo.FavouriteProducts");
        }
    }
}
