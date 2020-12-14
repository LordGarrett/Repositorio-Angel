namespace Proyecto_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class componentes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computadoras", "ComponentesID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Computadoras", "ComponentesID");
        }
    }
}
