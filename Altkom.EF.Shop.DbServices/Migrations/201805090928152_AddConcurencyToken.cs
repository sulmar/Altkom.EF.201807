namespace Altkom.EF.Shop.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConcurencyToken : DbMigration
    {
        public override void Up()
        {
            AlterStoredProcedure(
                "dbo.Customer_Update",
                p => new
                    {
                        Id = p.Int(),
                        FirstName = p.String(maxLength: 50),
                        FirstName_Original = p.String(maxLength: 50),
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
                      WHERE (([Id] = @Id) AND (([FirstName] = @FirstName_Original) OR ([FirstName] IS NULL AND @FirstName_Original IS NULL)))"
            );
            
            AlterStoredProcedure(
                "dbo.Customer_Delete",
                p => new
                    {
                        Id = p.Int(),
                        FirstName_Original = p.String(maxLength: 50),
                    },
                body:
                    @"DELETE [dbo].[Customers]
                      WHERE (([Id] = @Id) AND (([FirstName] = @FirstName_Original) OR ([FirstName] IS NULL AND @FirstName_Original IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
