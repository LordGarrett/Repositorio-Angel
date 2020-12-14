namespace Proyecto_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Clientes", "Apellidos", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Clientes", "Telefono", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Clientes", "Direccion", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Clientes", "Email", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Clientes", "Direccion", c => c.String(maxLength: 250));
            AlterColumn("dbo.Clientes", "Telefono", c => c.String(maxLength: 30));
            AlterColumn("dbo.Clientes", "Apellidos", c => c.String(maxLength: 20));
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(maxLength: 20, unicode: false));
        }
    }
}
