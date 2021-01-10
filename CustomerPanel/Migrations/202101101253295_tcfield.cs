namespace CustomerPanel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tcfield : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Tc", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Tc", c => c.Int(nullable: false));
        }
    }
}
