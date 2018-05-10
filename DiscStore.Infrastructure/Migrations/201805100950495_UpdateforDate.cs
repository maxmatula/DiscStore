namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateforDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "PremiereDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "PremiereDate", c => c.DateTime(nullable: false));
        }
    }
}
