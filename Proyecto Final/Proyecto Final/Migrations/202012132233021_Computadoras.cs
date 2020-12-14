namespace Proyecto_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Computadoras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computadoras",
                c => new
                    {
                        ComputadoraID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 35, unicode: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ComputadoraID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Computadoras");
        }
    }
}
