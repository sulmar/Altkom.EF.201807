namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "DateOrder", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "DateOrder", c => c.DateTime(nullable: false));
        }
    }
}
