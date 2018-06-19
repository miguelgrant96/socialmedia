using project2._4.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.DAL.Migrations.Seeds
{
    public class IdentityFrameworkSeed
    {
        private DatabaseContext Db;

        private SeedVersion seedVersion;

        public IdentityFrameworkSeed(DatabaseContext context) {
            this.Db = context;
            seedVersion = new SeedVersion("98F6D46F-1D1C-4501-8727-97B798AEF284");

            if (Db.SeedVersions.Find(seedVersion.Id) != null)
                return;

            //Adding Data.
            this.AddClient();

            Db.SeedVersions.Add(seedVersion);
            Db.SaveChanges();
        }

        private void AddClient()
        {
            Client Website = new Client()
            {
                Id = Guid.NewGuid(),
                Active = true,
                AllowedOrigin = "*",
                Client_ID = "WebSite",
                Name = "Project 2.4 socialMedia Website",
                RefreshTokenLifeTime = 30,
                Secret = "4E939AE2-A552-4FD3-84B4-B54ECB7A02AB"
            };

            Client Mobile = new Client()
            {
                Id = Guid.NewGuid(),
                Active = true,
                AllowedOrigin = "*",
                Client_ID = "Mobile",
                Name = "Project 2.4 socialMedia App",
                RefreshTokenLifeTime = 30,
                Secret = "E408D852-E46C-4E9F-9FE6-A1D020F90A1E"
            };

            Db.Clients.Add(Website);
            Db.Clients.Add(Mobile);
            Db.SaveChanges();
        }
    }
}
