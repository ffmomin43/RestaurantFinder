namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertbl1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "UserId");
        }
    }
}
