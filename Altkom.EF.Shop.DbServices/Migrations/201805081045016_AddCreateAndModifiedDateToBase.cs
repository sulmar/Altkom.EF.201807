namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateAndModifiedDateToBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Customers", "ModifiedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Orders", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Orders", "ModifiedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.OrderDetails", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.OrderDetails", "ModifiedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Items", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Items", "ModifiedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ModifiedDate");
            DropColumn("dbo.Items", "CreateDate");
            DropColumn("dbo.OrderDetails", "ModifiedDate");
            DropColumn("dbo.OrderDetails", "CreateDate");
            DropColumn("dbo.Orders", "ModifiedDate");
            DropColumn("dbo.Orders", "CreateDate");
            DropColumn("dbo.Customers", "ModifiedDate");
            DropColumn("dbo.Customers", "CreateDate");
        }
    }
}
