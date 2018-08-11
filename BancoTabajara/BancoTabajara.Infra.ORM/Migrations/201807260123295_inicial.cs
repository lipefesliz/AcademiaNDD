namespace BancoTabajara.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBClientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Cpf = c.String(maxLength: 50),
                        Rg = c.String(maxLength: 50),
                        Nascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBContas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Limite = c.Double(nullable: false),
                        Saldo = c.Double(nullable: false),
                        Ativada = c.Boolean(nullable: false),
                        Cliente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBClientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.TBMovimentacoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Valor = c.Double(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Conta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBContas", t => t.Conta_Id)
                .Index(t => t.Conta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBMovimentacoes", "Conta_Id", "dbo.TBContas");
            DropForeignKey("dbo.TBContas", "Cliente_Id", "dbo.TBClientes");
            DropIndex("dbo.TBMovimentacoes", new[] { "Conta_Id" });
            DropIndex("dbo.TBContas", new[] { "Cliente_Id" });
            DropTable("dbo.TBMovimentacoes");
            DropTable("dbo.TBContas");
            DropTable("dbo.TBClientes");
        }
    }
}
