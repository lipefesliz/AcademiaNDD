namespace Anderson.MF7.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vinitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBFuncionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Sobrenome = c.String(nullable: false, maxLength: 50),
                        Usuario = c.String(nullable: false, maxLength: 50),
                        Senha = c.String(nullable: false, maxLength: 20),
                        Ativo = c.Boolean(nullable: false),
                        Cargo = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBGastos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100),
                        Data = c.DateTime(nullable: false),
                        Preco = c.Double(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Funcionario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBFuncionarios", t => t.Funcionario_Id, cascadeDelete: true)
                .Index(t => t.Funcionario_Id);
            
            CreateTable(
                "dbo.TBUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBGastos", "Funcionario_Id", "dbo.TBFuncionarios");
            DropIndex("dbo.TBGastos", new[] { "Funcionario_Id" });
            DropTable("dbo.TBUsers");
            DropTable("dbo.TBGastos");
            DropTable("dbo.TBFuncionarios");
        }
    }
}
