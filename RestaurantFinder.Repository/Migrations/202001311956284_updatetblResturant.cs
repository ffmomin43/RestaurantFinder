namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetblResturant : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurants", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
