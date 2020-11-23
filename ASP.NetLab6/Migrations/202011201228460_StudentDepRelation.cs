namespace ASP.NetLab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentDepRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Department_DeptId", c => c.Int());
            CreateIndex("dbo.Students", "Department_DeptId");
            AddForeignKey("dbo.Students", "Department_DeptId", "dbo.Departments", "DeptId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Department_DeptId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Department_DeptId" });
            DropColumn("dbo.Students", "Department_DeptId");
        }
    }
}
