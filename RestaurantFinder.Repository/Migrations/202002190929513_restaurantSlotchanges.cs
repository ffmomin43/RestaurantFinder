namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restaurantSlotchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantSlots", "Restaurantid", c => c.Int(nullable: false));
            DropColumn("dbo.RestaurantSlots", "RestaurantDayId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantSlots", "RestaurantDayId", c => c.Int(nullable: false));
            DropColumn("dbo.RestaurantSlots", "Restaurantid");
        }
    }
}
