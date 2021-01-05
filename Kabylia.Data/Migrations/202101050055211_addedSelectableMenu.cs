namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSelectableMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "Select", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "Select");
        }
    }
}
