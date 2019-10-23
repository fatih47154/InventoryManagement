namespace InventoryManagement.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryManagementDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operation", "Guncel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Operation", "Guncel");
        }
    }
}
