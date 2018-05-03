namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PremiereDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PremiereDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PremiereDate");
        }
    }
}
