namespace Kabylia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedMenuOnOrder : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Order", name: "Order_OrderId", newName: "menu_MenuId");
            AddColumn("dbo.Order", "MenuId", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "menu_MenuId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Order", new[] { "menu_MenuId" });
            DropColumn("dbo.Order", "MenuId");
            RenameColumn(table: "dbo.Order", name: "menu_MenuId", newName: "Order_OrderId");
        }
    }
}
