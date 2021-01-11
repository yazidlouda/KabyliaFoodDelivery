namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedReviewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Reviews = c.String(),
                        CustomerId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Review", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Review", new[] { "RestaurantId" });
            DropIndex("dbo.Review", new[] { "CustomerId" });
            DropTable("dbo.Review");
        }
    }
}
