namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLastNameOnCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
