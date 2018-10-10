namespace Anderson.ORM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBCargos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBDepartamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBDependentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Idade = c.Int(nullable: false),
                        Funcionario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBFuncionarios", t => t.Funcionario_Id)
                .Index(t => t.Funcionario_Id);
            
            CreateTable(
                "dbo.TBFuncionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cargo_Id = c.Int(nullable: false),
                        Departamento_Id = c.Int(nullable: false),
                        Endereco_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBCargos", t => t.Cargo_Id)
                .ForeignKey("dbo.TBDepartamentos", t => t.Departamento_Id)
                .ForeignKey("dbo.TBEnderecos", t => t.Endereco_Id)
                .Index(t => t.Cargo_Id)
                .Index(t => t.Departamento_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.TBEnderecos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rua = c.String(nullable: false, maxLength: 100, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 100, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 100, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBProjetos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataInicio = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjetoFuncionario",
                c => new
                    {
                        Projeto_Id = c.Int(nullable: false),
                        Funcionario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Projeto_Id, t.Funcionario_Id })
                .ForeignKey("dbo.TBProjetos", t => t.Projeto_Id)
                .ForeignKey("dbo.TBFuncionarios", t => t.Funcionario_Id)
                .Index(t => t.Projeto_Id)
                .Index(t => t.Funcionario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBDependentes", "Funcionario_Id", "dbo.TBFuncionarios");
            DropForeignKey("dbo.ProjetoFuncionario", "Funcionario_Id", "dbo.TBFuncionarios");
            DropForeignKey("dbo.ProjetoFuncionario", "Projeto_Id", "dbo.TBProjetos");
            DropForeignKey("dbo.TBFuncionarios", "Endereco_Id", "dbo.TBEnderecos");
            DropForeignKey("dbo.TBFuncionarios", "Departamento_Id", "dbo.TBDepartamentos");
            DropForeignKey("dbo.TBFuncionarios", "Cargo_Id", "dbo.TBCargos");
            DropIndex("dbo.ProjetoFuncionario", new[] { "Funcionario_Id" });
            DropIndex("dbo.ProjetoFuncionario", new[] { "Projeto_Id" });
            DropIndex("dbo.TBFuncionarios", new[] { "Endereco_Id" });
            DropIndex("dbo.TBFuncionarios", new[] { "Departamento_Id" });
            DropIndex("dbo.TBFuncionarios", new[] { "Cargo_Id" });
            DropIndex("dbo.TBDependentes", new[] { "Funcionario_Id" });
            DropTable("dbo.ProjetoFuncionario");
            DropTable("dbo.TBProjetos");
            DropTable("dbo.TBEnderecos");
            DropTable("dbo.TBFuncionarios");
            DropTable("dbo.TBDependentes");
            DropTable("dbo.TBDepartamentos");
            DropTable("dbo.TBCargos");
        }
    }
}
