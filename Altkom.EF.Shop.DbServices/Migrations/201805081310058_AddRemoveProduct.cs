namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemoveProduct : DbMigration
    {
        public override void Up()
        {
            var body = "DELETE FROM dbo.Items WHERE ItemType = 'P' AND Id = @Id";

            CreateStoredProcedure("uspDeleteProduct", p => new { Id = p.Int() }, body);
        }
        
        public override void Down()
        {
            DropStoredProcedure("uspDeleteProduct");
        }
    }
}
