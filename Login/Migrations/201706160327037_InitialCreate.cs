namespace Login.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Usuario_nombre = c.String(nullable: false),
                        Contraseña = c.String(nullable: false),
                        ConfirmarContraseña = c.String(),
                        Email = c.String(nullable: false),
                        Sexo = c.String(),
                        Activo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
