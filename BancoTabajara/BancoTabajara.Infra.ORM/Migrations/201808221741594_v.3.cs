namespace BancoTabajara.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Usuario", newName: "TBUsuarios");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TBUsuarios", newName: "Usuario");
        }
    }
}
