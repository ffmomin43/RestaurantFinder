namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class savedeloyeerror : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RestaurantTables", "userid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantTables", "userid", c => c.Int(nullable: false));
        }
    }
}
