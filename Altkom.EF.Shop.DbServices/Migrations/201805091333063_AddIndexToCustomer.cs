namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToCustomer : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Customers", "Birthday");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "Birthday" });
        }
    }
}
