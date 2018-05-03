namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelUpdateAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Artist", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Artist");
        }
    }
}
