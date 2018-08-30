using Anderson.MF7.Infra.ORM.Contexts;
using Anderson.MF7.Infra.ORM.Migrations;
using System.Data.Entity;

namespace Anderson.MF7.Infra.ORM.Initializer
{
    /// <summary>
    /// Inicializador do Banco de dados.
    /// 
    /// Essa classe define a estratégia de inicializaçaõ do banco.
    /// </summary>
    public class DbInitializer : MigrateDatabaseToLatestVersion<AndersonMF7DbContext, Configuration>
    {
    }
}
