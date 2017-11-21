namespace keyswine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WineBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Description = c.String(),
                        CategoryId = c.Int(),
                        Age = c.Int(nullable: false),
                        Photo = c.Binary(),
                        PurchaseDate = c.DateTime(nullable: false),
                        WinemakerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Winemakers", t => t.WinemakerId)
                .Index(t => t.CategoryId)
                .Index(t => t.WinemakerId);
            
            CreateTable(
                "dbo.Winemakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wines", "WinemakerId", "dbo.Winemakers");
            DropForeignKey("dbo.Wines", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Wines", new[] { "WinemakerId" });
            DropIndex("dbo.Wines", new[] { "CategoryId" });
            DropTable("dbo.Winemakers");
            DropTable("dbo.Wines");
            DropTable("dbo.Categories");
        }
    }
}
