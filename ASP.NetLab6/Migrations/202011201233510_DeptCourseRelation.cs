namespace ASP.NetLab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeptCourseRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentCourses",
                c => new
                    {
                        Department_DeptId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Department_DeptId, t.Course_CourseId })
                .ForeignKey("dbo.Departments", t => t.Department_DeptId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Department_DeptId)
                .Index(t => t.Course_CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentCourses", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.DepartmentCourses", "Department_DeptId", "dbo.Departments");
            DropIndex("dbo.DepartmentCourses", new[] { "Course_CourseId" });
            DropIndex("dbo.DepartmentCourses", new[] { "Department_DeptId" });
            DropTable("dbo.DepartmentCourses");
        }
    }
}
