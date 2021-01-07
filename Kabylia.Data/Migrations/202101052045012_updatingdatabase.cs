namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingdatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "IsStarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "IsStarred");
        }
    }
}
