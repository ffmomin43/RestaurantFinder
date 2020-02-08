namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsTrendingcolumnadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "IsTrending", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "IsTrending");
        }
    }
}
