namespace ASP.NetLab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentDepRelation1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Department_DeptId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Department_DeptId" });
            RenameColumn(table: "dbo.Students", name: "Department_DeptId", newName: "DeptId");
            AlterColumn("dbo.Students", "DeptId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "DeptId");
            AddForeignKey("dbo.Students", "DeptId", "dbo.Departments", "DeptId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DeptId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DeptId" });
            AlterColumn("dbo.Students", "DeptId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "DeptId", newName: "Department_DeptId");
            CreateIndex("dbo.Students", "Department_DeptId");
            AddForeignKey("dbo.Students", "Department_DeptId", "dbo.Departments", "DeptId");
        }
    }
}
