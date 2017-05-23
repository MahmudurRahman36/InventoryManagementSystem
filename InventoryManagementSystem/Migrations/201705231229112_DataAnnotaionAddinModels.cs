namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotaionAddinModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "GroupName", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "ItemName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "ItemName", c => c.String());
            AlterColumn("dbo.Groups", "GroupName", c => c.String());
        }
    }
}
