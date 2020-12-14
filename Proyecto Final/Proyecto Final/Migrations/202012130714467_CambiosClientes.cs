namespace Proyecto_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosClientes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Clientes", "Direccion", c => c.String(maxLength: 250));
            AlterColumn("dbo.Clientes", "Email", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Email", c => c.String());
            AlterColumn("dbo.Clientes", "Direccion", c => c.String());
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(maxLength: 20));
        }
    }
}
