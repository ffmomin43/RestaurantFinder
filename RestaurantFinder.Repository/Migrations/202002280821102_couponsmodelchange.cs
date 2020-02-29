namespace RestaurantFinder.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class couponsmodelchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantCouponsMasters", "Discount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantCouponsMasters", "Discount");
        }
    }
}
