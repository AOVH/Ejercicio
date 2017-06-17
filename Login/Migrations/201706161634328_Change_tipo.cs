namespace Login.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_tipo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Activo", c => c.Int(nullable: false));
        }
    }
}
