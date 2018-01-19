namespace keyswine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigraBd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wines", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Wines", "WinemakerId", "dbo.Winemakers");
            DropIndex("dbo.Wines", new[] { "CategoryId" });
            DropIndex("dbo.Wines", new[] { "WinemakerId" });
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Wines", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Wines", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Wines", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Wines", "WinemakerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Winemakers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Winemakers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Winemakers", "Phone", c => c.String(nullable: false));
            CreateIndex("dbo.Wines", "CategoryId");
            CreateIndex("dbo.Wines", "WinemakerId");
            AddForeignKey("dbo.Wines", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Wines", "WinemakerId", "dbo.Winemakers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wines", "WinemakerId", "dbo.Winemakers");
            DropForeignKey("dbo.Wines", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Wines", new[] { "WinemakerId" });
            DropIndex("dbo.Wines", new[] { "CategoryId" });
            AlterColumn("dbo.Winemakers", "Phone", c => c.String());
            AlterColumn("dbo.Winemakers", "Email", c => c.String());
            AlterColumn("dbo.Winemakers", "Name", c => c.String());
            AlterColumn("dbo.Wines", "WinemakerId", c => c.Int());
            AlterColumn("dbo.Wines", "CategoryId", c => c.Int());
            AlterColumn("dbo.Wines", "Description", c => c.String());
            AlterColumn("dbo.Wines", "ProductName", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            CreateIndex("dbo.Wines", "WinemakerId");
            CreateIndex("dbo.Wines", "CategoryId");
            AddForeignKey("dbo.Wines", "WinemakerId", "dbo.Winemakers", "Id");
            AddForeignKey("dbo.Wines", "CategoryId", "dbo.Categories", "Id");
        }
    }
}
