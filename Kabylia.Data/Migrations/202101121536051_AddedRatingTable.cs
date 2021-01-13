namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRatingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RestaurantRating = c.Int(nullable: false),
                        DeliveryDriverRating = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        DeliveryDriverId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        DeliveryDriver_DriverId = c.Int(),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.DeliveryDriver", t => t.DeliveryDriver_DriverId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.CustomerId)
                .Index(t => t.DeliveryDriver_DriverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rating", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Rating", "DeliveryDriver_DriverId", "dbo.DeliveryDriver");
            DropForeignKey("dbo.Rating", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Rating", new[] { "DeliveryDriver_DriverId" });
            DropIndex("dbo.Rating", new[] { "CustomerId" });
            DropIndex("dbo.Rating", new[] { "RestaurantId" });
            DropTable("dbo.Rating");
        }
    }
}
