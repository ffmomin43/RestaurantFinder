namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RestaurantLocations", "Name");
            DropColumn("dbo.RestaurantLocations", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantLocations", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.RestaurantLocations", "Name", c => c.String());
        }
    }
}
