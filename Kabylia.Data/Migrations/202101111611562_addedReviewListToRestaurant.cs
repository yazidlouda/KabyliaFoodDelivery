namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedReviewListToRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "CustomerName", c => c.String());
            DropColumn("dbo.Restaurant", "Review");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurant", "Review", c => c.String());
            DropColumn("dbo.Review", "CustomerName");
        }
    }
}
