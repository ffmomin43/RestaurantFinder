namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRestauranttbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantTables", "userid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantTables", "userid");
        }
    }
}
