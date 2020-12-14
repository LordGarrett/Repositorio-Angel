namespace Proyecto_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class componentescambios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Componentes",
                c => new
                    {
                        ComponentesID = c.Int(nullable: false, identity: true),
                        ComputadoraID = c.Int(nullable: false),
                        Microprocesador = c.String(nullable: false, maxLength: 50, unicode: false),
                        Ram = c.String(nullable: false, maxLength: 50, unicode: false),
                        PlacaMadre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Almacenamiento = c.String(nullable: false, maxLength: 50, unicode: false),
                        TarjetaVideo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Gabinete = c.String(nullable: false, maxLength: 50, unicode: false),
                        FuenteDePoder = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ComponentesID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Componentes");
        }
    }
}
