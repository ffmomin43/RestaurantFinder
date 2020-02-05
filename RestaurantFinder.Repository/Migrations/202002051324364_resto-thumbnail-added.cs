namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restothumbnailadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "ThumbnailImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "ThumbnailImageUrl");
        }
    }
}
