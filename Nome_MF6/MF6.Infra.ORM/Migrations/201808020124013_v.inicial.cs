namespace MF6.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vinicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBImpressoras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(nullable: false, maxLength: 100),
                        Rede = c.String(nullable: false, maxLength: 100),
                        EmUso = c.Boolean(nullable: false),
                        TonerColorido_Id = c.Int(nullable: false),
                        TonerPreto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Toner", t => t.TonerColorido_Id)
                .ForeignKey("dbo.Toner", t => t.TonerPreto_Id)
                .Index(t => t.TonerColorido_Id)
                .Index(t => t.TonerPreto_Id);
            
            CreateTable(
                "dbo.Toner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nivel = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBImpressoras", "TonerPreto_Id", "dbo.Toner");
            DropForeignKey("dbo.TBImpressoras", "TonerColorido_Id", "dbo.Toner");
            DropIndex("dbo.TBImpressoras", new[] { "TonerPreto_Id" });
            DropIndex("dbo.TBImpressoras", new[] { "TonerColorido_Id" });
            DropTable("dbo.Toner");
            DropTable("dbo.TBImpressoras");
        }
    }
}
