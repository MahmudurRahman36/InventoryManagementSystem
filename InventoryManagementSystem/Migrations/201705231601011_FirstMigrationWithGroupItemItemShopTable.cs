namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrationWithGroupItemItemShopTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: false)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.ItemShops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoOfItems = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemShops", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "GroupId", "dbo.Groups");
            DropIndex("dbo.ItemShops", new[] { "ItemId" });
            DropIndex("dbo.Items", new[] { "GroupId" });
            DropTable("dbo.ItemShops");
            DropTable("dbo.Items");
            DropTable("dbo.Groups");
        }
    }
}
