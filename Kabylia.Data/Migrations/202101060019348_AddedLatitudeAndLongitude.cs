namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLatitudeAndLongitude : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeliveryDriver", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.DeliveryDriver", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeliveryDriver", "Longitude");
            DropColumn("dbo.DeliveryDriver", "Latitude");
        }
    }
}
