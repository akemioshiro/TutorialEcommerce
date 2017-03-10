using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Repositories.EntityTypeConfigurations;

namespace TutotrialEcommerce.Repositories
{
    public class EfDbContext:DbContext
    {
        public EfDbContext():base("EfDbContext")
        {            
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // remove tabelas no plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // tirando as duas propriedades evita que sejam removidos os relacionamentos em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            // todas as propriedades do tipo string serao varchar automaticamente
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(50));

            modelBuilder.Configurations.Add(new UsuarioConfigurations());
        }

    }
}
