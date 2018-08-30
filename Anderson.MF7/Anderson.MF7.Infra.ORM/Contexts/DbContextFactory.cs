using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Anderson.MF7.Infra.ORM.Contexts
{
    /// <summary>
    /// Essa classe resolve o problema do Migration que apresentava erro ao iniciar o AndersonMF7DbContext 
    /// quando havia construtor COM parâmetros.
    /// 
    /// Não existe um ponto de chamada para essa classe. 
    /// 
    /// O próprio Migrations procura no Assembly uma classe que implementa IDbContextFactory
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DbContextFactory : IDbContextFactory<AndersonMF7DbContext>
    {
        public AndersonMF7DbContext Create()
        {
            return new AndersonMF7DbContext();
        }
    }
}
