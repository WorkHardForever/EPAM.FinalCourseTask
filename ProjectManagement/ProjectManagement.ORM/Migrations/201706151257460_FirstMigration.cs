namespace ProjectManagement.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "Employee_Id", "dbo.People");
            DropForeignKey("dbo.Tasks", "Manager_Id", "dbo.People");
            DropForeignKey("dbo.AspNetUsers", "WorkAccount_Id", "dbo.People");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tasks", new[] { "Person_Id" });
            DropIndex("dbo.Tasks", new[] { "Person_Id1" });
            DropIndex("dbo.Tasks", new[] { "Employee_Id" });
            DropIndex("dbo.Tasks", new[] { "Manager_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "WorkAccount_Id" });
            RenameColumn(table: "dbo.Tasks", name: "Person_Id", newName: "ManagerPerson_Id");
            RenameColumn(table: "dbo.Tasks", name: "Person_Id1", newName: "EmployeePerson_Id");
            AlterColumn("dbo.Tasks", "ManagerPerson_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "EmployeePerson_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "ManagerPerson_Id");
            CreateIndex("dbo.Tasks", "EmployeePerson_Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Tasks", "Employee_Id");
            DropColumn("dbo.Tasks", "Manager_Id");
            DropColumn("dbo.AspNetUsers", "WorkAccount_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "WorkAccount_Id", c => c.Int());
            AddColumn("dbo.Tasks", "Manager_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "Employee_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Tasks", new[] { "EmployeePerson_Id" });
            DropIndex("dbo.Tasks", new[] { "ManagerPerson_Id" });
            AlterColumn("dbo.Tasks", "EmployeePerson_Id", c => c.Int());
            AlterColumn("dbo.Tasks", "ManagerPerson_Id", c => c.Int());
            RenameColumn(table: "dbo.Tasks", name: "EmployeePerson_Id", newName: "Person_Id1");
            RenameColumn(table: "dbo.Tasks", name: "ManagerPerson_Id", newName: "Person_Id");
            CreateIndex("dbo.AspNetUsers", "WorkAccount_Id");
            CreateIndex("dbo.Tasks", "Manager_Id");
            CreateIndex("dbo.Tasks", "Employee_Id");
            CreateIndex("dbo.Tasks", "Person_Id1");
            CreateIndex("dbo.Tasks", "Person_Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUsers", "WorkAccount_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Tasks", "Manager_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Tasks", "Employee_Id", "dbo.People", "Id");
        }
    }
}
