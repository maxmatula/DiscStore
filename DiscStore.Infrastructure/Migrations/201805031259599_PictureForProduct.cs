namespace DiscStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureForProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PictureData", c => c.Binary());
            AddColumn("dbo.Products", "PictureMimeType", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Products", "PictureMimeType");
            DropColumn("dbo.Products", "PictureData");
        }
    }
}
