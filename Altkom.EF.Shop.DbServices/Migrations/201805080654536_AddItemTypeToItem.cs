namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemTypeToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ItemType", c => c.String(nullable: false, maxLength: 128));
            Sql("UPDATE dbo.Items SET ItemType = left(Discriminator, 1)");
            DropColumn("dbo.Items", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            Sql("UPDATE dbo.Items SET Discriminator = case ItemType when 'S' then 'Service' when 'P' then 'Product' end");
            DropColumn("dbo.Items", "ItemType");
        }
    }
}
