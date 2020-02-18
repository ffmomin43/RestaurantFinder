namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restauranrtbladd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Restaurants", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Description");
            DropColumn("dbo.Restaurants", "Number");
        }
    }
}
