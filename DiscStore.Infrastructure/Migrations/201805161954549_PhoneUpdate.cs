namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShippingDetails", "Phone", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShippingDetails", "Phone", c => c.String(nullable: false));
        }
    }
}
