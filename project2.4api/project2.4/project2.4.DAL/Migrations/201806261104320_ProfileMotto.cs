namespace project2._4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileMotto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileInfoes", "Motto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileInfoes", "Motto");
        }
    }
}
