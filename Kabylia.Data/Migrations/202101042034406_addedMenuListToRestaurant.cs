namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMenuListToRestaurant : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menu", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menu", "Price", c => c.Int(nullable: false));
        }
    }
}
