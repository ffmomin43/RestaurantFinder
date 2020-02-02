namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThumbnailImageUrladded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryMasters", "ThumbnailImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CategoryMasters", "ThumbnailImageUrl");
        }
    }
}
