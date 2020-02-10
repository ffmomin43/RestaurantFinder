namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetblRestaurantDishes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantDishes", "ThumbnailImageUrl", c => c.String());
            DropColumn("dbo.RestaurantDishes", "Url1");
            DropColumn("dbo.RestaurantDishes", "Url2");
            DropColumn("dbo.RestaurantDishes", "Url3");
            DropColumn("dbo.RestaurantDishes", "Url4");
            DropColumn("dbo.RestaurantDishes", "Url5");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantDishes", "Url5", c => c.String());
            AddColumn("dbo.RestaurantDishes", "Url4", c => c.String());
            AddColumn("dbo.RestaurantDishes", "Url3", c => c.String());
            AddColumn("dbo.RestaurantDishes", "Url2", c => c.String());
            AddColumn("dbo.RestaurantDishes", "Url1", c => c.String());
            DropColumn("dbo.RestaurantDishes", "ThumbnailImageUrl");
        }
    }
}
