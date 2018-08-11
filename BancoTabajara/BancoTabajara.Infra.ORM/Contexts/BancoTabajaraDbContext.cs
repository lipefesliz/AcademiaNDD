using BancoTabajara.Domain.Features.Clientes;
using BancoTabajara.Domain.Features.Contas;
using BancoTabajara.Domain.Features.Movimentacoes;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.CodeAnalysis;

namespace BancoTabajara.Infra.ORM.Contexts
{
    [ExcludeFromCodeCoverage]
    public class BancoTabajaraDbContext : DbContext
    {
        public BancoTabajaraDbContext(string connection = "Name=BancoTabajaraDbContext") : base(connection)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected BancoTabajaraDbContext(DbConnection connection) : base(connection, true) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
