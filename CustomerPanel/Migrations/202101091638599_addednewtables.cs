namespace CustomerPanel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerCafes",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        Cafe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.Cafe_Id })
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cafes", t => t.Cafe_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Cafe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerCafes", "Cafe_Id", "dbo.Cafes");
            DropForeignKey("dbo.CustomerCafes", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.CustomerCafes", new[] { "Cafe_Id" });
            DropIndex("dbo.CustomerCafes", new[] { "Customer_Id" });
            DropTable("dbo.CustomerCafes");
        }
    }
}
