namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdateForDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Descirption", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Descirption", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
