namespace project2._4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedDiscussions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Text = c.String(),
                        Feed_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feeds", t => t.Feed_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Feed_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        Text = c.String(),
                        Text1 = c.String(),
                        VideoUrl = c.String(),
                        DescriptionText = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Creator_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Creator_Id)
                .Index(t => t.Creator_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedDiscussions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.FeedDiscussions", "Feed_Id", "dbo.Feeds");
            DropForeignKey("dbo.Feeds", "Creator_Id", "dbo.Users");
            DropIndex("dbo.Feeds", new[] { "Creator_Id" });
            DropIndex("dbo.FeedDiscussions", new[] { "User_Id" });
            DropIndex("dbo.FeedDiscussions", new[] { "Feed_Id" });
            DropTable("dbo.Feeds");
            DropTable("dbo.FeedDiscussions");
        }
    }
}
