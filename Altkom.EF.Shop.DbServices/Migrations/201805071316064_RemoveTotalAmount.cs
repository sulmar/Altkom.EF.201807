namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTotalAmount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
