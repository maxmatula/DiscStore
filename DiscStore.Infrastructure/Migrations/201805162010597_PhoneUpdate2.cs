namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneUpdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShippingDetails", "Phone", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShippingDetails", "Phone", c => c.Int(nullable: false));
        }
    }
}
