using Anderson.ORM.Domain.Features.Cargos;
using Anderson.ORM.Domain.Features.Departamentos;
using Anderson.ORM.Domain.Features.Dependentes;
using Anderson.ORM.Domain.Features.Enderecos;
using Anderson.ORM.Domain.Features.Funcionarios;
using Anderson.ORM.Domain.Features.Projetos;
using Anderson.ORM.Infra.Data.Features.Cargos;
using Anderson.ORM.Infra.Data.Features.Departamentos;
using Anderson.ORM.Infra.Data.Features.Dependentes;
using Anderson.ORM.Infra.Data.Features.Enderecos;
using Anderson.ORM.Infra.Data.Features.Funcionarios;
using Anderson.ORM.Infra.Data.Features.Projetos;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Anderson.ORM.Infra.Data.Base
{
    public class AndersonORMContext : DbContext
    {
        public AndersonORMContext() : base("MF_ORM_Anderson")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new CargoConfiguration());
            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new DependenteConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioConfiguration());
            modelBuilder.Configurations.Add(new ProjetoConfiguration());
        }
    }
}
