namespace ProjectManagement.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "WorkAccount_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "WorkAccount_Id");
            AddForeignKey("dbo.AspNetUsers", "WorkAccount_Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "WorkAccount_Id", "dbo.People");
            DropIndex("dbo.AspNetUsers", new[] { "WorkAccount_Id" });
            DropColumn("dbo.AspNetUsers", "WorkAccount_Id");
        }
    }
}
