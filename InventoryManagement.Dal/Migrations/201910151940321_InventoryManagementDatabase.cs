namespace InventoryManagement.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryManagementDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Number = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Operation",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Surname = c.String(maxLength: 200),
                        OperationTime = c.DateTime(nullable: false),
                        LocationId = c.Guid(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        StoreId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        OperationTypeId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .ForeignKey("dbo.OperationType", t => t.OperationTypeId)
                .ForeignKey("dbo.Store", t => t.StoreId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.LocationId)
                .Index(t => t.CompanyId)
                .Index(t => t.StoreId)
                .Index(t => t.UserId)
                .Index(t => t.OperationTypeId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperationType",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SerialNumber = c.String(maxLength: 20),
                        OperationTime = c.DateTime(nullable: false),
                        InventoryNumber = c.String(maxLength: 20),
                        WarrantyStart = c.DateTime(nullable: false),
                        Kullanimda = c.Boolean(nullable: false),
                        ModelId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        StatusId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Model", t => t.ModelId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.ModelId)
                .Index(t => t.UserId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        DeviceTypeId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeviceType", t => t.DeviceTypeId)
                .Index(t => t.DeviceTypeId);
            
            CreateTable(
                "dbo.DeviceType",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Surname = c.String(maxLength: 200),
                        Username = c.String(maxLength: 200),
                        Password = c.String(maxLength: 30),
                        CompanyId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Store", "UserId", "dbo.User");
            DropForeignKey("dbo.Operation", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Store", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Operation", "StoreId", "dbo.Store");
            DropForeignKey("dbo.Store", "ModelId", "dbo.Model");
            DropForeignKey("dbo.Model", "DeviceTypeId", "dbo.DeviceType");
            DropForeignKey("dbo.Operation", "OperationTypeId", "dbo.OperationType");
            DropForeignKey("dbo.Operation", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Operation", "CompanyId", "dbo.Company");
            DropIndex("dbo.User", new[] { "CompanyId" });
            DropIndex("dbo.Model", new[] { "DeviceTypeId" });
            DropIndex("dbo.Store", new[] { "StatusId" });
            DropIndex("dbo.Store", new[] { "UserId" });
            DropIndex("dbo.Store", new[] { "ModelId" });
            DropIndex("dbo.Operation", new[] { "OperationTypeId" });
            DropIndex("dbo.Operation", new[] { "UserId" });
            DropIndex("dbo.Operation", new[] { "StoreId" });
            DropIndex("dbo.Operation", new[] { "CompanyId" });
            DropIndex("dbo.Operation", new[] { "LocationId" });
            DropTable("dbo.User");
            DropTable("dbo.Status");
            DropTable("dbo.DeviceType");
            DropTable("dbo.Model");
            DropTable("dbo.Store");
            DropTable("dbo.OperationType");
            DropTable("dbo.Location");
            DropTable("dbo.Operation");
            DropTable("dbo.Company");
        }
    }
}
