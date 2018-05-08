namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeliveryDateToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DeliveryDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "DeliveryDate");
        }
    }
}
