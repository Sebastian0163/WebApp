namespace keyswine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "Roles");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UsersRole");
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "UsersClaim");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "UsersLogin");
            RenameColumn(table: "dbo.Roles", name: "Id", newName: "RoleId");
            RenameColumn(table: "dbo.Users", name: "Id", newName: "UserId");
            RenameColumn(table: "dbo.UsersClaim", name: "Id", newName: "UsersClaimId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.UsersClaim", name: "UsersClaimId", newName: "Id");
            RenameColumn(table: "dbo.Users", name: "UserId", newName: "Id");
            RenameColumn(table: "dbo.Roles", name: "RoleId", newName: "Id");
            RenameTable(name: "dbo.UsersLogin", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UsersClaim", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
            RenameTable(name: "dbo.UsersRole", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.Roles", newName: "AspNetRoles");
        }
    }
}
