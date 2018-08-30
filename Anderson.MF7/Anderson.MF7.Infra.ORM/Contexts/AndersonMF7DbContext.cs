using Anderson.MF7.Domain.Features.Users;
using System.Data.Common;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace Anderson.MF7.Infra.ORM.Contexts
{
    /// <summary>
    /// Contexto de banco de dados do Anderson.MF7
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AndersonMF7DbContext : DbContext
    {
        public AndersonMF7DbContext(string connection = "Name=AndersonMF7DbContext") : base(connection)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// Test Only.
        /// 
        /// Esse construtor deve ser chamado pela classe de teste que herdará desse contexto.
        /// Para classes externas esse construtor não está acessível (protected).
        /// 
        /// </summary>
        /// <param name="connection"></param>
        protected AndersonMF7DbContext(DbConnection connection) : base(connection, true) { }

        // Stores por entidade do contexto
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Método que é executado quando o modelo de banco de dados está sendo criado pelo EF.
        /// Útil para realizar configurações
        /// </summary>
        /// <param name="modelBuilder">É o construtor de modelos do EF</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
