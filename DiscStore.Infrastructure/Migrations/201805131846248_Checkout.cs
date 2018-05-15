namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Checkout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Guid(nullable: false),
                        UserID = c.String(),
                        ShippingID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.ShippingDetails", t => t.ShippingID, cascadeDelete: true)
                .Index(t => t.ShippingID);
            
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ShippingID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        HouseNumber = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        UserID = c.String(),
                    })
                .PrimaryKey(t => t.ShippingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShippingID", "dbo.ShippingDetails");
            DropIndex("dbo.Orders", new[] { "ShippingID" });
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.Orders");
        }
    }
}
