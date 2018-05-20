namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuidAutoGeneratedByDb2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.OrderProducts", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ShippingID", "dbo.ShippingDetails");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.OrderProducts");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.ShippingDetails");
            AlterColumn("dbo.Categories", "CategoryID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "ProductID", c => c.Guid(nullable: false));
            AlterColumn("dbo.OrderProducts", "OrderProductID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Orders", "OrderID", c => c.Guid(nullable: false));
            AlterColumn("dbo.ShippingDetails", "ShippingID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Categories", "CategoryID");
            AddPrimaryKey("dbo.Products", "ProductID");
            AddPrimaryKey("dbo.OrderProducts", "OrderProductID");
            AddPrimaryKey("dbo.Orders", "OrderID");
            AddPrimaryKey("dbo.ShippingDetails", "ShippingID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.OrderProducts", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ShippingID", "dbo.ShippingDetails", "ShippingID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShippingID", "dbo.ShippingDetails");
            DropForeignKey("dbo.OrderProducts", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropPrimaryKey("dbo.ShippingDetails");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.OrderProducts");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.ShippingDetails", "ShippingID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Orders", "OrderID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.OrderProducts", "OrderProductID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Products", "ProductID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "CategoryID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.ShippingDetails", "ShippingID");
            AddPrimaryKey("dbo.Orders", "OrderID");
            AddPrimaryKey("dbo.OrderProducts", "OrderProductID");
            AddPrimaryKey("dbo.Products", "ProductID");
            AddPrimaryKey("dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Orders", "ShippingID", "dbo.ShippingDetails", "ShippingID", cascadeDelete: true);
            AddForeignKey("dbo.OrderProducts", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
    }
}