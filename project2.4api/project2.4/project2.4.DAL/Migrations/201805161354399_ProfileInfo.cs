namespace project2._4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Werk = c.String(),
                        School = c.String(),
                        Woonplaats = c.String(),
                        RelatieStatus = c.String(),
                        Hobbies = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProfileInfoes");
        }
    }
}
