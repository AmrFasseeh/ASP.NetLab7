namespace ASP.NetLab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lab7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Students", "UserName");
            DropColumn("dbo.Students", "Email");
        }
    }
}
