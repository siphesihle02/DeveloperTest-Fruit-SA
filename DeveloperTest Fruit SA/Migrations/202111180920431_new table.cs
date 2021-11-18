namespace DeveloperTest_Fruit_SA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        categoryCode = c.String(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.categoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productCode = c.String(),
                        productName = c.String(nullable: false),
                        description = c.String(),
                        categoryName = c.String(nullable: false),
                        price = c.Double(nullable: false),
                        image = c.String(nullable: false),
                        Category_categoryId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Category_categoryId)
                .Index(t => t.Category_categoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_categoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_categoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
