namespace project2._4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feedupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feeds", "Creator_Id", "dbo.Users");
            DropIndex("dbo.Feeds", new[] { "Creator_Id" });
            AddColumn("dbo.Feeds", "CreatorId", c => c.Guid(nullable: false));
            DropColumn("dbo.Feeds", "Creator_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feeds", "Creator_Id", c => c.Guid());
            DropColumn("dbo.Feeds", "CreatorId");
            CreateIndex("dbo.Feeds", "Creator_Id");
            AddForeignKey("dbo.Feeds", "Creator_Id", "dbo.Users", "Id");
        }
    }
}
