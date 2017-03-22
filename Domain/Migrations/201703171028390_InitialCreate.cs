namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Act",
                c => new
                    {
                        actID = c.Int(nullable: false, identity: true),
                        Active = c.String(),
                    })
                .PrimaryKey(t => t.actID);
            
            CreateTable(
                "dbo.Transportfleet",
                c => new
                    {
                        TranID = c.Int(nullable: false, identity: true),
                        Carname = c.String(nullable: false, maxLength: 50),
                        Owner = c.String(nullable: false, maxLength: 50),
                        Model = c.String(nullable: false),
                        Maxcapacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Extrainformation = c.String(),
                        Registrationnumber = c.String(nullable: false),
                        VIN = c.String(nullable: false),
                        actID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TranID)
                .ForeignKey("dbo.Act", t => t.actID)
                .Index(t => t.actID);
            
            CreateTable(
                "dbo.Carriage",
                c => new
                    {
                        CarriageID = c.Int(nullable: false, identity: true),
                        Target = c.String(nullable: false, maxLength: 50),
                        zamierzonadatawyslania = c.String(nullable: false, maxLength: 50),
                        rzeczywistadatawyslania = c.String(nullable: false, maxLength: 50),
                        OwnerDescription = c.String(nullable: false),
                        TranID = c.Int(nullable: false),
                        WarehousesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarriageID)
                .ForeignKey("dbo.Warehouses", t => t.WarehousesID)
                .ForeignKey("dbo.Transportfleet", t => t.TranID)
                .Index(t => t.TranID)
                .Index(t => t.WarehousesID);
            
            CreateTable(
                "dbo.Packs",
                c => new
                    {
                        PacksID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        OwnerDescription = c.String(nullable: false),
                        wymiarX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        wymiarY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        wymiarZ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Waga = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dataprzyjeciadomagazynu = c.DateTime(nullable: false),
                        datawyslaniazmagazynu = c.DateTime(),
                        dataodebrania = c.DateTime(),
                        WarehousesID = c.Int(nullable: false),
                        personID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PacksID)
                .ForeignKey("dbo.Person", t => t.personID)
                .ForeignKey("dbo.Warehouses", t => t.WarehousesID)
                .Index(t => t.WarehousesID)
                .Index(t => t.personID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        personID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(nullable: false, maxLength: 50),
                        Tel = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Concern = c.String(nullable: false),
                        ConcernAdress = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        NIP = c.String(nullable: false),
                        Pesel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.personID);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WarehousesID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        Tel = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        NIP = c.String(nullable: false),
                        actID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WarehousesID)
                .ForeignKey("dbo.Act", t => t.actID)
                .Index(t => t.actID);
            
            CreateTable(
                "dbo.PacksCarriages",
                c => new
                    {
                        PacksID = c.Int(nullable: false),
                        CarriageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PacksID, t.CarriageID })
                .ForeignKey("dbo.Packs", t => t.PacksID, cascadeDelete: true)
                .ForeignKey("dbo.Carriage", t => t.CarriageID, cascadeDelete: true)
                .Index(t => t.PacksID)
                .Index(t => t.CarriageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carriage", "TranID", "dbo.Transportfleet");
            DropForeignKey("dbo.Packs", "WarehousesID", "dbo.Warehouses");
            DropForeignKey("dbo.Carriage", "WarehousesID", "dbo.Warehouses");
            DropForeignKey("dbo.Warehouses", "actID", "dbo.Act");
            DropForeignKey("dbo.Packs", "personID", "dbo.Person");
            DropForeignKey("dbo.PacksCarriages", "CarriageID", "dbo.Carriage");
            DropForeignKey("dbo.PacksCarriages", "PacksID", "dbo.Packs");
            DropForeignKey("dbo.Transportfleet", "actID", "dbo.Act");
            DropIndex("dbo.PacksCarriages", new[] { "CarriageID" });
            DropIndex("dbo.PacksCarriages", new[] { "PacksID" });
            DropIndex("dbo.Warehouses", new[] { "actID" });
            DropIndex("dbo.Packs", new[] { "personID" });
            DropIndex("dbo.Packs", new[] { "WarehousesID" });
            DropIndex("dbo.Carriage", new[] { "WarehousesID" });
            DropIndex("dbo.Carriage", new[] { "TranID" });
            DropIndex("dbo.Transportfleet", new[] { "actID" });
            DropTable("dbo.PacksCarriages");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Person");
            DropTable("dbo.Packs");
            DropTable("dbo.Carriage");
            DropTable("dbo.Transportfleet");
            DropTable("dbo.Act");
        }
    }
}
