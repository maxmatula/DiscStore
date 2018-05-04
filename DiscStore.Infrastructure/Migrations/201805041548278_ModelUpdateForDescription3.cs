namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdateForDescription3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Products", "Descirption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Descirption", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Products", "Description");
        }
    }
}
