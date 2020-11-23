using System;
using System.Data.Entity;
using System.Linq;

namespace ASP.NetLab6.Models
{
    public class ASPModel1 : DbContext
    {
        // Your context has been configured to use a 'ASPModel1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ASP.NetLab6.Models.ASPModel1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ASPModel1' 
        // connection string in the application configuration file.
        public ASPModel1()
            : base("name=ASPModel1")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}