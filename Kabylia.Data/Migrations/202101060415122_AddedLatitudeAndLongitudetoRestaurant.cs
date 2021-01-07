namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLatitudeAndLongitudetoRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Restaurant", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "Longitude");
            DropColumn("dbo.Restaurant", "Latitude");
        }
    }
}
