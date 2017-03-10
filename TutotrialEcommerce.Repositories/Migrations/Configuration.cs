using TutotrialEcommerce.Repositories.Seeds;

namespace TutotrialEcommerce.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TutotrialEcommerce.Repositories.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TutotrialEcommerce.Repositories.EfDbContext context)
        {
            UsuarioSeed.Seed(context);
        }
    }
}
