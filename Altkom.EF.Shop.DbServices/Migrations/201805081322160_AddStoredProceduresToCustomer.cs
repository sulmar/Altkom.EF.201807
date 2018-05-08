namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoredProceduresToCustomer : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Customer_Insert",
                p => new
                    {
                        FirstName = p.String(maxLength: 50),
                        LastName = p.String(maxLength: 70),
                        DeliveryAddress_City = p.String(maxLength: 100),
                        DeliveryAddress_Street = p.String(maxLength: 100),
                        DeliveryAddress_PostCode = p.String(maxLength: 5, unicode: false),
                        DeliveryAddress_BuildingNumber = p.String(),
                        Birthday = p.DateTime(storeType: "datetime2"),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        ModifiedDate = p.DateTime(storeType: "datetime2"),
                    },
                body:
                    @"INSERT [dbo].[Customers]([FirstName], [LastName], [DeliveryAddress_City], [DeliveryAddress_Street], [DeliveryAddress_PostCode], [DeliveryAddress_BuildingNumber], [Birthday], [CreateDate], [ModifiedDate])
                      VALUES (@FirstName, @LastName, @DeliveryAddress_City, @DeliveryAddress_Street, @DeliveryAddress_PostCode, @DeliveryAddress_BuildingNumber, @Birthday, @CreateDate, @ModifiedDate)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Customers]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Customers] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Customer_Update",
                p => new
                    {
                        Id = p.Int(),
                        FirstName = p.String(maxLength: 50),
                        LastName = p.String(maxLength: 70),
                        DeliveryAddress_City = p.String(maxLength: 100),
                        DeliveryAddress_Street = p.String(maxLength: 100),
                        DeliveryAddress_PostCode = p.String(maxLength: 5, unicode: false),
                        DeliveryAddress_BuildingNumber = p.String(),
                        Birthday = p.DateTime(storeType: "datetime2"),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        ModifiedDate = p.DateTime(storeType: "datetime2"),
                    },
                body:
                    @"UPDATE [dbo].[Customers]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [DeliveryAddress_City] = @DeliveryAddress_City, [DeliveryAddress_Street] = @DeliveryAddress_Street, [DeliveryAddress_PostCode] = @DeliveryAddress_PostCode, [DeliveryAddress_BuildingNumber] = @DeliveryAddress_BuildingNumber, [Birthday] = @Birthday, [CreateDate] = @CreateDate, [ModifiedDate] = @ModifiedDate
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Customer_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Customers]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Customer_Delete");
            DropStoredProcedure("dbo.Customer_Update");
            DropStoredProcedure("dbo.Customer_Insert");
        }
    }
}
