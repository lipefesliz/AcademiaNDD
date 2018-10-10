namespace Anderson.ORM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBFuncionarios", "Cpf", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBFuncionarios", "Cpf");
        }
    }
}
