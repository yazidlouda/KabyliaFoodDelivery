namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgeolocalisationToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Customer", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "Longitude");
            DropColumn("dbo.Customer", "Latitude");
        }
    }
}
