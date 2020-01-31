namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.RestaurantsImages", "listImageUrl", c => c.String());
            DropColumn("dbo.RestaurantsImages", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantsImages", "ImageName", c => c.String());
            DropColumn("dbo.RestaurantsImages", "listImageUrl");
            DropColumn("dbo.Restaurants", "Discriminator");
        }
    }
}
