namespace ModernStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        PassWord = c.String(nullable: false, maxLength: 32, fixedLength: true),
                        Active = c.Boolean(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Customer", "User_Id");
            AddForeignKey("dbo.Customer", "User_Id", "dbo.User", "Id", cascadeDelete: true);
            DropColumn("dbo.Customer", "User_Username");
            DropColumn("dbo.Customer", "User_PassWord");
            DropColumn("dbo.Customer", "User_Active");
            DropColumn("dbo.Customer", "User_ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "User_ConfirmPassword", c => c.String());
            AddColumn("dbo.Customer", "User_Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customer", "User_PassWord", c => c.String(nullable: false, maxLength: 32, fixedLength: true));
            AddColumn("dbo.Customer", "User_Username", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.Customer", "User_Id", "dbo.User");
            DropIndex("dbo.Customer", new[] { "User_Id" });
            DropTable("dbo.User");
        }
    }
}
