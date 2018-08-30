using Anderson.MF7.Infra.ORM.Contexts;
using System.Data.Common;

namespace Anderson.MF7.Infra.ORM.Tests.Context
{
    /// <summary>
    /// Esse contexto deve ser usado para testar o EF através do Framework Effort
    /// </summary>
    public class FakeDbContext : AndersonMF7DbContext
    {
        public FakeDbContext(DbConnection connection) : base(connection)
        {
        }
    }
}
