namespace Login.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuarios_DB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuarios", "ConfirmarContraseña");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "ConfirmarContraseña", c => c.String());
        }
    }
}
