namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Color = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderDetails", "Item_Id", c => c.Int());
            CreateIndex("dbo.OrderDetails", "Item_Id");
            AddForeignKey("dbo.OrderDetails", "Item_Id", "dbo.Items", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Item_Id", "dbo.Items");
            DropIndex("dbo.OrderDetails", new[] { "Item_Id" });
            DropColumn("dbo.OrderDetails", "Item_Id");
            DropTable("dbo.Items");
        }
    }
}
