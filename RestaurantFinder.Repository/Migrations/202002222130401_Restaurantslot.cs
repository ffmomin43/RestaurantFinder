namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restaurantslot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantSlots", "SlotName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantSlots", "SlotName");
        }
    }
}
