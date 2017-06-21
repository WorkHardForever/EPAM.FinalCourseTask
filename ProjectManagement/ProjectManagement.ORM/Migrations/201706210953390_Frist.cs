namespace ProjectManagement.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Frist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfileId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfileId");
        }
    }
}
