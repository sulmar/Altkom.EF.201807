namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuildingNumberToAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DeliveryAddress_BuildingNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DeliveryAddress_BuildingNumber");
        }
    }
}
