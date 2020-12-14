namespace Proyecto_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaID = c.Int(nullable: false, identity: true),
                        ProductoID = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FacturaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Facturas");
        }
    }
}
