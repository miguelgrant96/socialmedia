namespace project2._4.DAL.Migrations
{
    using project2._4.DAL.Migrations.Seeds;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<project2._4.DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(project2._4.DAL.DatabaseContext context)
        {
            new IdentityFrameworkSeed(context);
        }
    }
}
