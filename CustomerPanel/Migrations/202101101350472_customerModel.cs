namespace CustomerPanel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerCafes", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomerCafes", "Cafe_Id", "dbo.Cafes");
            DropIndex("dbo.CustomerCafes", new[] { "Customer_Id" });
            DropIndex("dbo.CustomerCafes", new[] { "Cafe_Id" });
            AddColumn("dbo.Customers", "Cafe_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Cafe_Id");
            AddForeignKey("dbo.Customers", "Cafe_Id", "dbo.Cafes", "Id");
            DropTable("dbo.CustomerCafes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerCafes",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        Cafe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.Cafe_Id });
            
            DropForeignKey("dbo.Customers", "Cafe_Id", "dbo.Cafes");
            DropIndex("dbo.Customers", new[] { "Cafe_Id" });
            DropColumn("dbo.Customers", "Cafe_Id");
            CreateIndex("dbo.CustomerCafes", "Cafe_Id");
            CreateIndex("dbo.CustomerCafes", "Customer_Id");
            AddForeignKey("dbo.CustomerCafes", "Cafe_Id", "dbo.Cafes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerCafes", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
