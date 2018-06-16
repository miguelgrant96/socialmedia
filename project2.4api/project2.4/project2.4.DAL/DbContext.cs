using project2._4.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=Project2.4DB")
        {

        } 

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SeedVersion> SeedVersions { get; set; }
        public DbSet<ProfileInfo> ProfileInfo { get; set; }
        public DbSet<TextFeed> FeedTexts { get; set; }
        public DbSet<ImageFeed> ImageFeeds { get; set; }
        public DbSet<VideoFeed> VideoFeeds { get; set; }
        public DbSet<FeedDiscussion> FeedDiscussions { get; set; }

    }
}
