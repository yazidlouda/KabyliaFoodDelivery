namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Menu", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Menu");
        }
    }
}
