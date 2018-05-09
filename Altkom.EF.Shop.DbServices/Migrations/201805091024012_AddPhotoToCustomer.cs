namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Photo");
        }
    }
}
