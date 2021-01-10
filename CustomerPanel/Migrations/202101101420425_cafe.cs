namespace CustomerPanel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cafe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Cafe_Id", "dbo.Cafes");
            DropIndex("dbo.Customers", new[] { "Cafe_Id" });
            RenameColumn(table: "dbo.Customers", name: "Cafe_Id", newName: "CafeId");
            AlterColumn("dbo.Customers", "CafeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CafeId");
            AddForeignKey("dbo.Customers", "CafeId", "dbo.Cafes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CafeId", "dbo.Cafes");
            DropIndex("dbo.Customers", new[] { "CafeId" });
            AlterColumn("dbo.Customers", "CafeId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "CafeId", newName: "Cafe_Id");
            CreateIndex("dbo.Customers", "Cafe_Id");
            AddForeignKey("dbo.Customers", "Cafe_Id", "dbo.Cafes", "Id");
        }
    }
}
