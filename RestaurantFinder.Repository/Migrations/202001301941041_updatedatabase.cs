namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantLocations", "Name", c => c.String());
            AddColumn("dbo.RestaurantLocations", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantLocations", "Discriminator");
            DropColumn("dbo.RestaurantLocations", "Name");
        }
    }
}
